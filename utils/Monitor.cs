using Newtonsoft.Json;
using ProjectMonitor.utils;
using ServerInfo.config;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectMonitor
{
    class Monitor
    {
        private String title;
        private String url;
        private String warn;
        private Button button;

        public Monitor(String title, String url, String warn, Button button)
        {
            this.title = title;
            this.url = url;
            this.warn = warn;
            this.button = button;
        }
        public void monitorUrl()
        {
            String result = HttpUtils.postRequest(url, "", null);
            if ("success".Equals(result))
            {
                button.BackColor = Color.LimeGreen;
            }
            else
            {
                button.BackColor = Color.OrangeRed;
                if (!"".Equals(warn))
                {
                    String[] warnArray = warn.Split(";");
                    for (int index = 0; index<warnArray.Length;index++) {
                        String warnSingle = warnArray[index];
                        if (warnSingle.Contains("qyapi.weixin.qq.com"))
                        {
                            try
                            {
                                // 企业微信机器人地址
                                WorkWxSendMessage workWxSendMessage = new WorkWxSendMessage();
                                workWxSendMessage.msgtype = WorkWxSendMessage.MSGTYPE_TEXT;
                                WorkWxSendMessage.Text text = new WorkWxSendMessage.Text();
                                text.content = title + "服务异常！";
                                workWxSendMessage.text = text;
                                String robotSendContentJson = JsonConvert.SerializeObject(workWxSendMessage);
                                LogUtils.writeLog(robotSendContentJson);
                                HttpUtils.postRequest(warn, robotSendContentJson, HttpUtils.CONTENT_TYPE_APPLICATION_JSON);
                            }
                            catch (Exception e)
                            {
                                LogUtils.writeLog(e.StackTrace);
                            }
                        } else if (warnSingle.Contains("@163.com") || warnSingle.Contains("@qq.com") || warnSingle.Contains("@163.com"))
                        {
                            // 邮箱
                            String emailBody = title + "服务无法访问！";
                            EmailUtils emailUtis = new EmailUtils(Config.emailServer, warnSingle, Config.fromEmail, "服务监控", emailBody, Config.username, Config.password, Config.emailPort, true, true);
                            emailUtis.Send();
                        }
                        else
                        {
                            
                        }
                    }
                }
            }
        }
    }
}
