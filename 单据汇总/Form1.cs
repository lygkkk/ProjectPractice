using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 单据汇总
{
    public partial class Form1 : Form
    {
        public event Action<string> ConfirmClick; 
        public Form1()
        {
            InitializeComponent();
            button1.Click += (sender, args) => ConfirmClick.Invoke(textBox1.Text);
        }
    }
}
