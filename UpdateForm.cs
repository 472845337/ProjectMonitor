using ProjectMonitor;
using ProjectMonitor.config;
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
            MonitorSections.MonitorSection monitorSection = MonitorSections.getMonitorByKey(section);
            String title = monitorSection.title;
            String url = monitorSection.url;
            String warn = monitorSection.warn;
            UpdateForm_Title_TextBox.Text = title;
            UpdateForm_Url_TextBox.Text = url;
            UpdateForm_Warn_RichTextBox.Text = warn;
        }

        private void UpdateForm_Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateForm_Save_Button_Click(object sender, EventArgs e)
        {
            String title = UpdateForm_Title_TextBox.Text;
            String url = UpdateForm_Url_TextBox.Text;
            String warn = UpdateForm_Warn_RichTextBox.Text;
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
                iniUtils.IniWriteValue(Config.MonitorIniPath, section, "title", title);
                iniUtils.IniWriteValue(Config.MonitorIniPath, section, "url", url);
                iniUtils.IniWriteValue(Config.MonitorIniPath, section, "warn", warn);
                /* 生成新INI结束 ************************/
                // sections缓存数据新增
                MonitorSections.MonitorSection monitorSection = MonitorSections.getMonitorByKey(section);
                monitorSection.title = title;
                monitorSection.url = url;
                monitorSection.warn = warn;
                MonitorSections.updateMonitor(section, monitorSection);
                /* StartForm中更新服务按钮 *************/
                mainForm.updateButton(section);
                /* 更新服务按钮完成****** *************/
                // 关闭新增窗口
                UpdateForm_Cancel_Button_Click(sender, e);
            }
        }
    }
}
