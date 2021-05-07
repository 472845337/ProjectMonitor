using Newtonsoft.Json;
using ProjectMonitor.utils;
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
            /// 系统参数读取
            /// 
            // 计时器频率
            String intervalStr = iniUtils.IniReadValue(Config.SystemIniPath, "system", "interval");
            // 请求超时时间
            String timeoutStr = iniUtils.IniReadValue(Config.SystemIniPath, "system", "timeout");
            int interval = 0;
            int timeout = 0;
            if (null == intervalStr || "".Equals(intervalStr))
            {
                interval = Decimal.ToInt32(TimerInterval_Input.Minimum);
            }
            else
            {
                interval = int.Parse(intervalStr);
            }
            if (null == timeoutStr || "".Equals(timeoutStr))
            {
                timeout = Decimal.ToInt32(Timeout_Input.Minimum);
            }
            else
            {
                timeout = int.Parse(timeoutStr);
            }
            TimerInterval_Input.Value = interval;
            Timeout_Input.Value = timeout;
            Config.interval = interval;
            Config.timeout = timeout;
            // 监控邮件配置
            String emailServer = iniUtils.IniReadValue(Config.SystemIniPath, "email", "server");
            String emailPort = iniUtils.IniReadValue(Config.SystemIniPath, "email", "port");
            String fromEmail = iniUtils.IniReadValue(Config.SystemIniPath, "email", "fromEmail");
            String username = iniUtils.IniReadValue(Config.SystemIniPath, "email", "username");
            String password = iniUtils.IniReadValue(Config.SystemIniPath, "email", "password");
            Config.emailServer = emailServer;
            Config.emailPort = emailPort;
            Config.fromEmail = fromEmail;
            Config.username = username;
            Config.password = password;
            // 日志
            String logFileName = iniUtils.IniReadValue(Config.SystemIniPath, "log", "filename");
            String logSwitch = iniUtils.IniReadValue(Config.SystemIniPath, "log", "switch");
            Config.logFileName = logFileName;
            if(logSwitch != null && "on".Equals(logSwitch))
            {
                Config.logSwitch = true;
            }
            // 主窗体赋值，以便其它地方调用
            Config.mainForm = this;
            // 动态创建按钮控件
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

            // 按钮可用初始化
            Monitor_Button.Enabled = true;
            Stop_Button.Enabled = false;
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
            button.Size = new System.Drawing.Size(90, 70);
            button.TabIndex = 0;
            if ("0".Equals(stat))
            {
                // 当前任务是暂停
                setButtonBackColor(button, Color.LightGray);
            }
            else if ("1".Equals(stat))
            {
                // 当前任务是启动
                setButtonBackColor(button, Color.AliceBlue);
            }
            Image image = Image.FromFile(@"resource\icons\computer.ico");
            button.BackgroundImageLayout = ImageLayout.None;
            button.BackgroundImage = image;

            button.Text = buttonText;
            button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button.Font = new Font("微软雅黑", 8);

            button.MouseHover += new EventHandler(BtnMouseHover);

            // 右键按钮添加事件
            ContextMenuStrip rightMenu = new ContextMenuStrip();
            ToolStripMenuItem monitorItem = new ToolStripMenuItem();
            monitorItem.Name = section + "MouseRightMenu_Monitor";
            monitorItem.Text = "监听";
            monitorItem.Tag = section;
            monitorItem.Click += new EventHandler(BtnRightMonitorClick);
            rightMenu.Items.Add(monitorItem);
            ToolStripMenuItem stopItem = new ToolStripMenuItem();
            stopItem.Name = section + "MouseRightMenu_Stop";
            stopItem.Text = "停止";
            stopItem.Tag = section;
            stopItem.Click += new EventHandler(BtnRightStopClick);
            rightMenu.Items.Add(stopItem);
            ToolStripMenuItem updateItem = new ToolStripMenuItem();
            updateItem.Name = section + "MouseRightMenu_Update";
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
            String section = (String)menuItem.Tag;
            // 开始监听状态置为1
            iniUtils.IniWriteValue(Config.MonitorIniPath, section, "stat", "1");
            // 按钮背景置白
            Button button = (Button)ControlUtils.GetControlInstance(flowLayoutPanel, section);
            setButtonBackColor(button, Color.AliceBlue);
        }
        /**
         * 右键停止按钮点击事件
         * */
        private void BtnRightStopClick(Object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            String section = (String)menuItem.Tag;
            // 停止监听
            iniUtils.IniWriteValue(Config.MonitorIniPath, section, "stat", "0");
            // 按钮背景置灰
            Button button = (Button)ControlUtils.GetControlInstance(flowLayoutPanel, section);
            setButtonBackColor(button, Color.LightGray);
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
            Monitor_Button.Enabled = false;
            Stop_Button.Enabled = true;
            timer.Interval = Config.interval * 1000;
            timer.Enabled = true;

        }
        /// <summary>
        /// 停止按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_Button_Click(object sender, EventArgs e)
        {
            Monitor_Button.Enabled = true;
            Stop_Button.Enabled = false;
            timer.Enabled = false;
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
                object buttonObj = ControlUtils.GetControlInstance(flowLayoutPanel, section);

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

        /// <summary>
        /// 时间频率框值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerInterval_Input_ValueChanged(object sender, EventArgs e)
        {
            int interval = Decimal.ToInt32(TimerInterval_Input.Value);
            iniUtils.IniWriteValue(Config.SystemIniPath, "system", "interval", Convert.ToString(interval));
            Config.interval = interval;
            timer.Interval = interval * 1000;
        }


        /// <summary>
        /// 超时框数值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timeout_Input_ValueChanged(object sender, EventArgs e)
        {
            int timeout = Decimal.ToInt32(Timeout_Input.Value);
            iniUtils.IniWriteValue(Config.SystemIniPath, "system", "timeout", Convert.ToString(timeout));
            Config.timeout = timeout;
        }

        private void setButtonBackColor(Button button, Color color)
        {
            button.BackColor = color;
        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            // 企业微信机器人地址
            WorkWxSendMessage workWxSendMessage = new WorkWxSendMessage();
            workWxSendMessage.msgtype = WorkWxSendMessage.MSGTYPE_TEXT;
            WorkWxSendMessage.Text text = new WorkWxSendMessage.Text();
            text.content = "测试服务异常！";
            workWxSendMessage.text = text;
            String robotSendContentJson = JsonConvert.SerializeObject(workWxSendMessage);
            String result = HttpUtils.postRequest("https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key=455329a4-9065-4b79-8ccd-d8bf61d58815", robotSendContentJson, HttpUtils.CONTENT_TYPE_APPLICATION_JSON);
            LogUtils.writeLog(result);
        }*/
       /// <summary>
       /// 开关按钮改变事件
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void LogSwitch_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = LogSwitch_CheckBox.Checked;
            Config.logSwitch = isChecked;
            String logSwitchStr = "";
            if (isChecked)
            {
                logSwitchStr = "on";
            }
            else
            {
                logSwitchStr = "off";
            }
            iniUtils.IniWriteValue(Config.SystemIniPath, "log", "switch", logSwitchStr);
        }
    }
}
