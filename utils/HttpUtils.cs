using ProjectMonitor.utils;
using System;
using System.IO;
using System.Net;

namespace ProjectMonitor
{
    class HttpUtils
    {
        public static String CONTENT_TYPE_APPLICATION_JSON = "application/json";
        public static String postRequest(String url, String data, String contentType)
        {
            //定义request并设置request的路径
            WebRequest request = WebRequest.Create(url);

            //定义请求的方式
            request.Method = "POST";
            //设置request的MIME类型及内容长度
            request.ContentType = StringUtils.isEmpty(contentType)? "application/x-www-form-urlencoded":contentType;
            //定义response为前面的request响应
            WebResponse response = null;
            Stream dataStream = null;
            StreamReader reader = null;
            string responseFromServer = "";
            try
            {
                response = request.GetResponse();

                //定义response字符流
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();//读取所有
                Console.WriteLine(responseFromServer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //关闭资源
                if (null != reader)
                {
                    reader.Close();
                }
                if ( null != dataStream)
                {
                    dataStream.Close();
                }
                if (null != response)
                {
                    response.Close();
                }
            }
            
            return responseFromServer;
        }
    }
}
