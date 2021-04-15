using ServerInfo;
using ServerInfo.config;
using ServerInfo.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<String> sectionList = iniUtils.ReadSections(Config.IniPath);
            for (int i = 0; i < sectionList.Count; i++)
            {

                String section = sectionList[i];
                // 创建按钮
                addButton(section);
            }
        }

        /// <summary>
        /// 添加按钮
        /// </summary>

        public void addButton(String section)
        {

            String buttonText = iniUtils.IniReadValue(Config.IniPath, section, "title");
            Button button = new Button();
            button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            button.Location = new System.Drawing.Point(3, 0);
            button.Name = section;
            button.Size = new System.Drawing.Size(90, 90);
            button.TabIndex = 0;
            Image image = Image.FromFile(@"mstsc.ico");
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
            monitorItem.Name = "ServerRightMenu_Monitor";
            monitorItem.Text = "监听";
            monitorItem.Tag = section;
            monitorItem.Click += new EventHandler(BtnRightMonitorClick);
            rightMenu.Items.Add(monitorItem);
            ToolStripMenuItem stopItem = new ToolStripMenuItem();
            stopItem.Name = "ServerRightMenu_Stop";
            stopItem.Text = "停止";
            stopItem.Tag = section;
            stopItem.Click += new EventHandler(BtnRightStopClick);
            rightMenu.Items.Add(stopItem);
            ToolStripMenuItem updateItem = new ToolStripMenuItem();
            updateItem.Name = "ServerRightMenu_Update";
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
            String title = iniUtils.IniReadValue(Config.IniPath, section, "title");
            btn.Text = title;
        }
        // 鼠标移动到按钮事件
        ToolTip toolTip1 = new ToolTip();
        private void BtnMouseHover(Object sender, EventArgs e)
        {
            Button currentBtn = (Button)sender;
            String section = currentBtn.Name;
            String title = iniUtils.IniReadValue(Config.IniPath, section, "title");

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
            // rdp文件参数
            
        }
        /**
         * 右键停止按钮点击事件
         * */
        private void BtnRightStopClick(Object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

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
    }
}
