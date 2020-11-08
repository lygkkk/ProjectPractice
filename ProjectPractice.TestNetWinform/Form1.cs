using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using cs;
namespace ProjectPractice.TestNetWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //check();
        }

        static void check()
        {
            int buffer = 0, bufferLen = 0;
            int state = 0, stateLen = 0;
            string para;
            //测试账号密码均为:test001
            //为了演示,我将关键文本参数以明文方式直接传递,实际应用过程中,不推荐这样做,你需要把明文加密后存储,使用时解密在传参.
            //此为常规验证,后台添加软件后,使用此代码段测试
            if (!hwd.hwd_init("dev.huweidun.cn", "9f3e2994e38236f16fbd053c435df53c", "b8ed5ee6-2dcb-4db8-ac6c-aee8259e5cb8", "S3Ery0nX6qzdg7wdPSS0yDmQunfbE5KZ", true, 0, 0, "", true))//初始化验证
            {
                //hwd.hwd_init()
                //如果初始化失败,则弹出提示并退出.
                hwd.hwd_getLastErrorMsg(ref buffer, ref bufferLen);
                hwd.hwd_msg("提示", hwd.hwd_getStr(buffer, bufferLen), 1 + 32768);
                hwd.hwd_exit(0);
            }

            hwd.hwd_loadLoginWindow("1.0", "", 0, "12345");//载入内置登录窗口,由于使用内置窗口登录,不需要心跳,内置窗口自动心跳
            hwd.hwd_getUserInfo("state", ref state, ref stateLen);
            if (hwd.hwd_getStr(state, stateLen) == "1")
            {
                //如果能到达这里,说明用户登录成功,直接可进行业务逻辑
                hwd.hwd_getSoftInfo("para", ref buffer, ref bufferLen);//获取软件自定义常量指针
                para = hwd.hwd_getStr(buffer, bufferLen);//获取软件自定义常量字符串
                Console.WriteLine(para);
            }

            Console.ReadLine();
        }

        private  void button1_ClickAsync(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            Chart.re
            chart1.Refresh();
             Task.Run(() => {
                string str = "www";
                 this.Invoke(new Action<string>(s1 =>
                 {
                     Debug.WriteLine("1");
                     textBox1.Text = s1;
                 }), str);
            });
            Debug.WriteLine("2");
        }
    }
}
