using System;
using System.Collections.Generic;

namespace ProjectMonitor.utils
{
    class WorkWxSendMessage
    {
        public static String MSGTYPE_TEXT = "text";
        public static String MSGTYPE_MARKDOWN = "markdown";
        public static String MSGTYPE_IMAGE = "image";
        public static String MSGTYPE_NEWS = "news";
        public static String MSGTYPE_FILE = "file";


        /** 消息类型,使用类中的常量 */
        public string msgtype { get; set; }
        /** 文本类型数据 */
        public Text text { get; set; }
        /** 段落类型数据 */
        public Markdown markdown { get; set; }
        /** 图片类型数据 */
        public Image image { get; set; }
        /** 新闻类型数据 */
        public News news { get; set; }
        /** 文件类型数据 */
        public File file { get; set; }

        /**
		 * 文本類型
		 * @copyright 
		 * @author 周小洲
		 * @create 2021年2月3日
		 * @modify
		 * @description
		 */
        public class Text
        {

            /** 文本内容 */
            public String content { get; set; }

            /** 提醒指定人员 */
            private List<String> mentionedList
            {
                get;
                set;
            }

            /** 提醒指定手机号 */
            private List<String> mentionedMobileList
            {
                get;
                set;
            }

        }

        /**
         * 段落類型
         * @copyright 
         * @author 周小洲
         * @create 2021年2月3日
         * @modify
         * @description
         */
        public class Markdown
        {
            private String content { get; set; }
        }

        /**
         * 图片類型
         * @copyright 
         * @author 周小洲
         * @create 2021年2月3日
         * @modify
         * @description
         */
        public class Image
        {
            private String base64 { get; set; }

            private String md5 { get; set; }

        }

        /**
         * 图文数据
         * @copyright 
         * @author 周小洲
         * @create 2021年2月3日
         * @modify
         * @description
         */
        public class News
        {
            private List<Article> articles
            {
                get; set;
            }


            public class Article
            {
                private String title { get; set; }
                private String description { get; set; }
                private String url { get; set; }
                private String picurl { get; set; }


            }
        }

        /**
         * 文件类型
         * @copyright 
         * @author 周小洲
         * @create 2021年2月3日
         * @modify
         * @description
         */
        public class File
        {
            private String mediaId { get; set; }


        }
    }

}
