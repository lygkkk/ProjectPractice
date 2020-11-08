using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPractice.WinFormAsync
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            //InvokeOnClick(button1,  button1.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task t = Task.Run(() => {
                string str = "www";
                this.Invoke(new Action<string>(s1 =>  label1.Text = s1), str);
            });
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
