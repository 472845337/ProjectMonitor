using ServerInfo;
using ServerInfo.config;
using ServerInfo.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ProjectMonitor
{
    public partial class MainForm : Form
    {
        IniUtils iniUtils = new IniUtils();
        public MainForm()
        {
            InitializeComponent();
        }
        // 不能使用窗体中的timer控件，要使用线程timer
        System.Timers.Timer timer = new System.Timers.Timer();
        // 监听线程map
        Dictionary<String, Thread> dic = new Dictionary<string, Thread>();
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            // 系统参数读取
            String interval = iniUtils.IniReadValue(Config.SystemIniPath, "system", "interval");
            String timeout = iniUtils.IniReadValue(Config.SystemIniPath, "system", "timeout");
            if (null == interval || "".Equals(interval))
            {
                interval = Convert.ToString(TimerInterval_Input.Minimum);
            }
            if (null == timeout || "".Equals(timeout))
            {
                timeout = Convert.ToString(Timeout_Input.Minimum);
            }
            TimerInterval_Input.Value = int.Parse(interval);
            Timeout_Input.Value = int.Parse(timeout);

            List<String> sectionList = iniUtils.ReadSections(Config.MonitorIniPath);
            for (int i = 0; i < sectionList.Count; i++)
            {
                String section = sectionList[i];
                // 创建按钮
                addButton(section);
            }
            // 给时间控件绑定事件
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_total_Tick);
            timer.AutoReset = true;
        }

        /// <summary>
        /// 添加按钮
        /// </summary>

        public void addButton(String section)
        {

            String buttonText = iniUtils.IniReadValue(Config.MonitorIniPath, section, "title");
            // 状态，是暂停还是启动状态
            String stat = iniUtils.IniReadValue(Config.MonitorIniPath, section, "stat");
            Button button = new Button();
            button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            button.Location = new System.Drawing.Point(3, 0);
            button.Name = section;
            button.Size = new System.Drawing.Size(90, 90);
            button.TabIndex = 0;
            button.BackColor = Color.AliceBlue;
            Image image = Image.FromFile(@"resource\icons\computer.ico");
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.BackgroundImage = image;

            button.Text = buttonText;
            button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button.Font = new Font("微软雅黑", 10);

            button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            // button.MouseClick += new MouseEventHandler(BtnClick);
            button.MouseHover += new EventHandler(BtnMouseHover);

            // 右键按钮添加事件
            ContextMenuStrip rightMenu = new ContextMenuStrip();
            ToolStripMenuItem monitorItem = new ToolStripMenuItem();
            monitorItem.Name = "MouseRightMenu_Monitor";
            monitorItem.Text = "监听";
            monitorItem.Tag = section;
            monitorItem.Click += new EventHandler(BtnRightMonitorClick);
            if ("0".Equals(stat))
            {
                monitorItem.Enabled = false;
            }
            rightMenu.Items.Add(monitorItem);
            ToolStripMenuItem stopItem = new ToolStripMenuItem();
            stopItem.Name = "MouseRightMenu_Stop";
            stopItem.Text = "停止";
            stopItem.Tag = section;
            stopItem.Click += new EventHandler(BtnRightStopClick);
            if ("1".Equals(stat))
            {
                stopItem.Enabled = false;
            }
            rightMenu.Items.Add(stopItem);
            ToolStripMenuItem updateItem = new ToolStripMenuItem();
            updateItem.Name = "MouseRightMenu_Update";
            updateItem.Text = "修改";
            updateItem.Tag = section;
            updateItem.Click += new EventHandler(BtnRightUpdateClick);
            rightMenu.Items.Add(updateItem);
            button.ContextMenuStrip = rightMenu;
            flowLayoutPanel.Controls.Add(button);
                     
        }

        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="section"></param>
        public void updateButton(String section)
        {
            Button btn = (Button)flowLayoutPanel.Controls[section];
            String title = iniUtils.IniReadValue(Config.MonitorIniPath, section, "title");
            btn.Text = title;
        }
        // 鼠标移动到按钮事件
        ToolTip toolTip1 = new ToolTip();
        private void BtnMouseHover(Object sender, EventArgs e)
        {
            Button currentBtn = (Button)sender;
            String section = currentBtn.Name;
            String title = iniUtils.IniReadValue(Config.MonitorIniPath, section, "title");

            // 设置显示样式
            //toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            toolTip1.InitialDelay = 200;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 0;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框
            //  设置伴随的对象.
            toolTip1.SetToolTip(currentBtn, title);
        }

        /**
       * 右键监听按钮点击事件
       * */
        private void BtnRightMonitorClick(Object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            // 开始监听状态置为1
            iniUtils.IniWriteValue(Config.MonitorIniPath, (String)menuItem.Tag, "stat", "1");
        }
        /**
         * 右键停止按钮点击事件
         * */
        private void BtnRightStopClick(Object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            // 停止监听
            iniUtils.IniWriteValue(Config.MonitorIniPath, (String)menuItem.Tag, "stat", "0");
        }

        /**
        * 右键修改按钮点击事件
        * */
        private void BtnRightUpdateClick(Object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            UpdateForm updateForm = new UpdateForm();
            updateForm.setMainForm(this);
            updateForm.setSection((String)menuItem.Tag);
            updateForm.ShowDialog();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            // 先要把主窗口放以弹出窗口中，以便弹出窗口调用主窗口函数
            addForm.setMainForm(this);
            addForm.ShowDialog();
        }

        /// <summary>
        /// 监控按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Monitor_Button_Click(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Enabled = true;
        }

        /// <summary>
        /// 定时器任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_total_Tick(object sender, EventArgs e)
        {
            List<String> sectionList = iniUtils.ReadSections(Config.MonitorIniPath);
            for (int i = 0; i < sectionList.Count; i++)
            {

                String section = sectionList[i];
                
                String title = iniUtils.IniReadValue(Config.MonitorIniPath, section, "title");
                String url = iniUtils.IniReadValue(Config.MonitorIniPath, section, "url");
                String warn = iniUtils.IniReadValue(Config.MonitorIniPath, section, "warn");
                String stat = iniUtils.IniReadValue(Config.MonitorIniPath, section, "stat");
                // 根据section获取控件
                object buttonObj = GetControlInstance(flowLayoutPanel, section);

                if ("".Equals(stat) || "1".Equals(stat))
                {
                    Monitor monitor = new Monitor(title, url, warn, ((Button)buttonObj));
                    // 查找线程字典中是否已经存在该线程
                    if (dic.ContainsKey(section))
                    {
                        Thread sectonThread = dic[section];
                        if (sectonThread.ThreadState.Equals(ThreadState.Running))
                        {
                            // 线程还在运行中
                            continue;
                        }
                        else
                        {
                            sectonThread = new Thread(new ThreadStart(monitor.monitorUrl));
                            sectonThread.Start();
                        }
                    }
                    else
                    {
                        Thread sectonThread = new Thread(new ThreadStart(monitor.monitorUrl));
                        sectonThread.Start();
                        dic.Add(section, sectonThread);
                    }
                    
                }
                else
                {
                    ((Button)buttonObj).BackColor = Color.LightSteelBlue;
                }
            }
        }

        private void monitorUrl()
        {
            
        }
        /// <summary>
        /// 根据指定容器和控件名字，获得控件
        /// </summary>
        /// <param name="obj">容器</param>
        /// <param name="strControlName">控件名字</param>
        /// <returns>控件</returns>
        private object GetControlInstance(object obj, string strControlName)
        {
            IEnumerator Controls = null;//所有控件
            Control c = null;//当前控件
            Object cResult = null;//查找结果
            if (obj.GetType() == this.GetType())//窗体
            {
                Controls = this.Controls.GetEnumerator();
            }
            else//控件
            {
                Controls = ((Control)obj).Controls.GetEnumerator();
            }
            while (Controls.MoveNext())//遍历操作
            {
                c = (Control)Controls.Current;//当前控件
                if (c.HasChildren)//当前控件是个容器
                {
                    cResult = GetControlInstance(c, strControlName);//递归查找
                    if (cResult == null)//当前容器中没有，跳出，继续查找
                        continue;
                    else
                    {
                        //找到控件，跳出循环
                        break;
                    }
                }
                else if (c.Name == strControlName)//不是容器，同时找到控件，返回
                {
                    cResult = c;
                    break;
                }
            }
            return cResult;//控件不存在
        }

        private void Stop_Button_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }
    }
}
