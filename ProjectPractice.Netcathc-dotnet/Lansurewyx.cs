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
    public partial class Lansurewyx : Form
    {
        public Lansurewyx()
        {
            InitializeComponent();
            Login("http://lansur.weidms.com/#/login");
        }

        private void Login(string url)
        {


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.Accept = "application/json, text/plain, */*";
            request.ContentType = "application/json;charset=UTF-8";
            request.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.142 Safari/537.36";
            request.KeepAlive = true;
            request.Referer = "http://lansur.weidms.com/";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
        }
    }
}
