using ProjectMonitor;
using ServerInfo.config;
using ServerInfo.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ServerInfo
{
    public partial class UpdateForm : Form
    {
        IniUtils iniUtils = new IniUtils();
        private MainForm mainForm;
        private String section;

        public void setMainForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }
        public void setSection(String section)
        {
            this.section = section;
        }
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            
            String title = iniUtils.IniReadValue(Config.IniPath, section, "title");
            String url = iniUtils.IniReadValue( Config.IniPath, section, "url");
            String port = iniUtils.IniReadValue(Config.IniPath, section, "port");
            String username = iniUtils.IniReadValue(Config.IniPath, section, "username");
            String password = iniUtils.IniReadValue(Config.IniPath, section, "password");
            UpdateForm_Title_TextBox.Text = title;
            UpdateForm_Url_TextBox.Text = url;
        }

        private void UpdateForm_Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateForm_Save_Button_Click(object sender, EventArgs e)
        {
            String title = UpdateForm_Title_TextBox.Text;
            String url = UpdateForm_Url_TextBox.Text;
            Boolean checkFlag = true;
            StringBuilder checkMsg = new StringBuilder();
            if ("".Equals(title))
            {
                checkFlag = false;
                checkMsg.Append("名称未填写\r\n");
            }
            if ("".Equals(url))
            {
                checkFlag = false;
                checkMsg.Append("地址未填写\r\n");
            }
            if (!checkFlag)
            {
                MessageBox.Show(checkMsg.ToString(), "错误");
            }
            else
            {
                /** 数据正常，修改ini数据，执行StartForm添加按钮和新增rdp文件操作 */
                // 生成title
                iniUtils.IniWriteValue(Config.IniPath, section, "title", title);
                iniUtils.IniWriteValue(Config.IniPath, section, "url", url);
                /* 生成新INI结束 ************************/
                /* StartForm中添加新服务按钮 *************/
                mainForm.updateButton(section);
                /* 添加新服务按钮完成****** *************/
                // 关闭新增窗口
                UpdateForm_Cancel_Button_Click(sender, e);
            }
        }
    }
}
