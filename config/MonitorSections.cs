using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMonitor.config
{
    class MonitorSections
    {
        private static List<String> sections;
        private static Dictionary<String, MonitorSection> dictionarys;


        public static void clear()
        {
            sections = null;
            dictionarys = null;
        }
        public static List<String> getAllSections()
        {
            return sections;
        }

        public static MonitorSection getMonitorByKey(String section)
        {
            if(null == dictionarys)
            {
                return null;
            }
            else
            {
                return dictionarys[section];
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="section"></param>
        /// <param name="monitor"></param>
        public static void updateMonitor(String section, MonitorSection monitorSection)
        {
            if (dictionarys == null)
            {
                dictionarys = new Dictionary<string, MonitorSection>();
                sections = new List<String>();
            }
            bool isExist = dictionarys.ContainsKey(section);
            if (isExist)
            {
                // 已经存在，修改原数据
                dictionarys[section] = monitorSection;
            }
            else
            {
                dictionarys.Add(section, monitorSection);
                sections.Add(section);
            }
        }
        public class MonitorSection
        {
            public String title { get; set; }
            public String url { get; set; }
            public String warn { get; set; }
            public String stat { get; set; }
        }
    }
}
