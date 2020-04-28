using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectPractice.WinFormAsync
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            InvokeOnClick(button1, new MouseEventArgs(MouseButtons.Left, 1, 20, 20, 1));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("aa");
            
        }
    }
}
