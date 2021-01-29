using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label button = (Label)sender;
            if (button != null)
            {
                button.Text = "定格";
            }
            
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
