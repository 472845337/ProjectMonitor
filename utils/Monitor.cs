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
                    HttpUtils.postRequest(warn, title + "服务异常！", HttpUtils.CONTENT_TYPE_APPLICATION_JSON);
                }
            }
        }
    }
}
