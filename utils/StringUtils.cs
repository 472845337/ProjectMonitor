using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMonitor.utils
{
    class StringUtils
    {
        public static Boolean isEmpty(String str)
        {
            Boolean isEmpty = false;
            if(null == str || "".Equals(str) || "null".Equals(str.ToLower()))
            {
                isEmpty = true;
            }
            return isEmpty;
        }
    }
}
