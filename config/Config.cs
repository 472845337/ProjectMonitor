using ProjectMonitor;
using System;

namespace ServerInfo.config
{
    class Config
    {
        public static String MonitorIniPath = "ini/Monitor.ini";
        public static String SystemIniPath = "ini/System.ini";
        public static String AppPath = System.AppDomain.CurrentDomain.BaseDirectory;
        // 主窗口，用于其它窗口或方法中
        public static MainForm mainForm;
        // 单位是秒
        public static int interval;
        // 单位是秒
        public static int timeout;

        public static String emailServer;

        public static String emailPort;

        public static String fromEmail;

        public static String username;

        public static String password;
    }
}
