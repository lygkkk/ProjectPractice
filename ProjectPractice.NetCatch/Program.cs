using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace ProjectPractice.NetCatch
{
    class Program
    {
        static void Main(string[] args)
        {
           GetVerificationCode();
           

            
       


        }

        #region 获取验证码

        public static void GetVerificationCode()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://sso.ematong.com");
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            httpWebRequest.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
        }

        #endregion


        public static string GetHtmlWithUtf(string url)
        {
            //if (!(url.Contains("http://") || url.Contains("https://")))
            //{
            //    url = "http://" + url;
            //}
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.UserAgent = "User-Agent: Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            req.Accept = "*/*";
            req.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
            req.ContentType = "text/xml";

            string sHTML = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            sHTML = reader.ReadToEnd();
                        }
                    }
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            sHTML = reader.ReadToEnd();
                        }
                    }
                }
                else
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            sHTML = reader.ReadToEnd();
                        }
                    }
                }
            }
            return sHTML;
        }
        
    }
}
