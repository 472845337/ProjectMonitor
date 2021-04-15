using System;
using System.Collections.Generic;
using System.Text;

namespace ServerInfo.config
{
    class Config
    {
        public static String MonitorIniPath = "ini/Monitor.ini";
        public static String SystemIniPath = "ini/System.ini";
        public static String AppPath = System.AppDomain.CurrentDomain.BaseDirectory;
    }
}
