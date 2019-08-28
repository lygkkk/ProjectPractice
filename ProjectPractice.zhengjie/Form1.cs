using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPractice.zhengjie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.button1.Click += sangeshaniao_click;
            this.button2.Click += sangeshaniao_click;
            this.button3.Click += sangeshaniao_click;
        }

        private void sangeshaniao_click(object send, EventArgs e)
        {

            var button = (Button) send;
            button.Text = "杭州市";
            //MessageBox.Show("1");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
