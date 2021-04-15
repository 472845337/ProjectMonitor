using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMonitor
{
    class Monitor
    {
        /// <summary> 
        /// 停止标记 
        /// </summary> 
        private bool StarMonitor = false;
        private String url;

        public void Start(String url)
        {
            this.url = url;
            System.Threading.Thread _Thread = new System.Threading.Thread(new System.Threading.ThreadStart(StartMonitor));
            StarMonitor = true;
            _Thread.Start();
        }
        /// <summary> 
        /// 开始监听 
        /// </summary> 
        public void StartMonitor()
        {
            while (StarMonitor)
            {
                String result = HttpUtils.postRequest(url,"");
            }
        }
    }
}
