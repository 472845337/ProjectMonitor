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
    public partial class AddForm : Form
    {
        private IniUtils iniUtils = new IniUtils();
        private MainForm mainForm;

        public void setMainForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddForm_Save_Button_Click(object sender, EventArgs e)
        {
            String title = AddForm_Title_TextBox.Text;
            String url = AddForm_Url_TextBox.Text;
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
                /** 数据正常，生成新的ini数据，执行StartForm添加按钮和新增rdp文件操作 */
                /* 生成新INI ****************************/
                String newSection = Guid.NewGuid().ToString();
                // 生成title
                iniUtils.IniWriteValue(Config.IniPath, newSection, "title", title);
                iniUtils.IniWriteValue(Config.IniPath, newSection, "url", url);
                /* 生成新INI结束 ************************/
                /* StartForm中添加新服务按钮 *************/
                mainForm.addButton(newSection);
                /* 添加新服务按钮完成****** *************/
                // 关闭新增窗口
                AddForm_Cancel_Button_Click(sender, e);
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
