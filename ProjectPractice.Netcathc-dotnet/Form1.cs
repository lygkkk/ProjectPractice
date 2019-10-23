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
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace ProjectPractice.Netcathc_dotnet
{
    public partial class Form1 : Form
    {
        private string _cookie = "";
        private List<string> _loginInfor = null;
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_load);
            this.button1.Click += new EventHandler(btn_Click);
        }

        private void Form1_load(object sender, EventArgs e)
        {
            GetLoginInfo(@"http://sso.ematong.com");

            GetVerificationCode(@"http://sso.ematong.com/captcha.jpg?", _cookie);

        }

        #region 获取登录前的Cookie以及其他信息

        /// <summary>
        /// 获取登录前的Cookie以及其他信息
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        private void GetLoginInfo(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            //httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            //httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.25 Safari/537.36 Core/1.70.3704.400 QQBrowser/10.4.3587.400";
            //httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            //httpWebRequest.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            //httpWebRequest.Headers.Add("Cache-Control", "max-age=0");

            //httpWebRequest.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8);
            string htmlString = myStreamReader.ReadToEnd();

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlString);
            var nodes = htmlDocument.DocumentNode.SelectNodes("//input[@type='hidden']").ToList();
            _loginInfor = new List<string>();
            nodes.ForEach(value => _loginInfor.Add(value.Attributes[1].Value + "=" + value.Attributes[2].Value + "&"));
            _cookie = (response.Headers.GetValues("Set-Cookie")[0].Split(';')[0]);
                 
        }

        #endregion

        #region 获取验证码图片

        private void GetVerificationCode(string url, string cookie)
        {
            Random random = new Random();
            var g = random.NextDouble();
            url += g;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpWebRequest.Method = "GET";
            //httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            httpWebRequest.Headers.Add("Cookie", cookie);
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
           
        }

        #endregion

        #region 登录

        private void Login()
        {
            string account = "userId=15906696262&";
            string pwd = "pwd=696262";
            string verificationCode = $"yzm={textBox1.Text}";

            string param = _loginInfor[0] + _loginInfor[1] + _loginInfor[2] + account + pwd + verificationCode;
            string param1 = account + pwd;
            byte[] paramBytes = Encoding.UTF8.GetBytes(param1);


            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create($@"http://sso.ematong.com/checkYzm.do?yzm={verificationCode}");
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create($@"http://bm.ematong.com/index");
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create($@"http://sso.ematong.com/login?service=http://bm.ematong.com/shiro-cas");


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($@"http://bm.ematong.com/public/getUserInfo?callback=?");
            
            request.Method = "POST";
            request.Referer = @"http://sso.ematong.com/login?service=http://bm.ematong.com/shiro-cas";
            request.ContentLength = paramBytes.Length;
            request.Headers.Add("cookie", _cookie);
            request.KeepAlive = true;

            
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(paramBytes, 0, paramBytes.Length);

            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
            string str = streamReader.ReadToEnd();


        }

        #endregion

        #region 按钮点击

        private void btn_Click(object sender, EventArgs e)
        {
            Login();
        }

        #endregion
    }
}
