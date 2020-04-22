using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPractice.CrossThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isTrue = true;

        private void PrintCurrentTime(string dateTime)
        {
          
                this.textBox1.Text = dateTime;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isTrue = true;
            //方法2
            Thread thread = new Thread(() =>
            {
                //此处写法会导致跨线程访问异常，线程间访问无效
                //原因是：UI界面控件，是由UI线程操控的，但是被新开启的线程访问了，导致跨线程访问无效的异常
                //解决办法有两种：
                //this.txtTime.Text = DateTime.Now.ToString();
                while (isTrue)
                {
                    //解决跨线程访问无效第二种方式
                    //if (!this.textBox1.InvokeRequired)
                    //{
                    //    this.textBox1.Text = DateTime.Now.ToString();
                    //}
                    //作用：InvokeRequired-如果是别的线程创建的此控件，则为true
                    //Invoke找到   创建    这个控件的    线程    去执行相应的操作，也就是避开子线程去访问主线程控件
                    //this.textBox1.Invoke(new Action<string>(s => this.textBox1.Text = s), DateTime.Now.ToString());//委托类的基类
                    //Console.WriteLine(DateTime.Now.ToString());
                    Thread.Sleep(1000);
                }
            });
            ////设置为后台线程后，关闭主窗口，thread线程同时跟着被关闭；false时主窗口关闭，thread线程仍然在执行
            thread.IsBackground = true;
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isTrue = false;
        }
    }
}
