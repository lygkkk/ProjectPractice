using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //    using (OleDbDataAdapter = new OleDbDataAdapter())
            //    {
            //        string[] arr =
            //    }


            var i = 0;
            Form form = new Form();

            Button btn = new Button
            {
                Text = "显示i当前数字",
                AutoSize = true
            };

            Button btn1 = new Button
            {
                Text = "关闭窗体",
                AutoSize = true
            };
            btn.Click += (sender, eventArgs) => 
            {
                MessageBox.Show(i.ToString());
                i++;
            };
            btn1.Click += (sender, eventArgs) => form.Close();
            form.Controls.Add(btn);
            form.Controls.Add(btn1);
            form.Controls[1].Location = new System.Drawing.Point(100, 0);
            form.ShowDialog();

            for (; i < 1000; i++)
            {
                Debug.Print(i.ToString());
            }

            form.ShowDialog();
        }

        public static void Test(TreeNode node)
        {
            
        }
    }
}
