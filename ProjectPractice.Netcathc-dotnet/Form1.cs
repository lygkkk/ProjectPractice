using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPractice.Netcathc_dotnet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_load);
        }

        private void Form1_load(object sender, EventArgs e)
        {
            

            GetVerificationCode(@"http://sso.ematong.com/captcha.jpg?", GetCookie(@"http://sso.ematong.com"));

            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://sso.ematong.com");
            //httpWebRequest.Method = "GET";
            //httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            //httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.25 Safari/537.36 Core/1.70.3704.400 QQBrowser/10.4.3587.400";
            //httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            //httpWebRequest.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            //httpWebRequest.Headers.Add("Cache-Control", "max-age=0");

            //httpWebRequest.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

            //HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            //var x = response.Headers.GetValues("Set-Cookie")[0].Split(';')[0];
            //Stream myResponseStream = response.GetResponseStream();
            //this.pictureBox1.Image = new Bitmap(myResponseStream);


            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            //string retString = myStreamReader.ReadToEnd();
            //myStreamReader.Close();
            //myResponseStream.Close();
        }

        #region 获取登录前的Cookie

        /// <summary>
        /// 获取登录前的Cookie
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        private string GetCookie(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.25 Safari/537.36 Core/1.70.3704.400 QQBrowser/10.4.3587.400";
            httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpWebRequest.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            httpWebRequest.Headers.Add("Cache-Control", "max-age=0");

            //httpWebRequest.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            return response.Headers.GetValues("Set-Cookie")[0].Split(';')[0];      
        }

        #endregion

        #region 获取验证码图片

        private string GetVerificationCode(string url, string cookie)
        {
            Random random = new Random();
            var g = random.NextDouble();
            url += g;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpWebRequest.Method = "GET";
            //httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            //httpWebRequest.Headers.Add("Cookie", cookie);
            //httpWebRequest.Headers.Add("Referer", "http://sso.ematong.com/login");
            //httpWebRequest.Referer = "http://sso.ematong.com/login";
            //httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.25 Safari/537.36 Core/1.70.3704.400 QQBrowser/10.4.3587.400";
            //httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            //httpWebRequest.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            //httpWebRequest.Headers.Add("Cache-Control", "max-age=0");
            //httpWebRequest.ContentType = "image/jpeg;charset=UTF-8";
            //httpWebRequest.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            this.pictureBox1.Image = new Bitmap(myResponseStream);

            //http://sso.ematong.com/captcha.jpg?0.9960488431683552
            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            //string retString = myStreamReader.ReadToEnd();
            //myStreamReader.Close();
            //myResponseStream.Close();

            return "1";
           
        }

        #endregion
    }
}
