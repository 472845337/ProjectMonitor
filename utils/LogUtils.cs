using ServerInfo.config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjectMonitor.utils
{
    class LogUtils
    {
        public static void writeLog(String log)
        {
            writeLog(log, Config.logFileName);
        }
        public static void writeLog(String log, String logFile)
        {
            if (!Config.logSwitch)
            {
                return;
            }
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                if (File.Exists(logFile))
                //验证文件是否存在，有则追加，无则创建
                {
                    fs = new FileStream(@logFile, FileMode.Append, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(@logFile, FileMode.Create, FileAccess.Write);
                }
                sw = new StreamWriter(fs);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "   ---   " + log);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (null != sw)
                {
                    sw.Close();
                }
                if (null != fs)
                {
                    fs.Close();
                }
            }
           
        }
    }
}
