using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int i = 3;
            //while (true)
            //{
            //    if (i == 0)
            //    {
            //        return;
            //    }

            //    i--;
            //}

            var node = new TreeNode
            {
                Text = "QQ"
            };

            Test(node);
        }

        public static void Test(TreeNode node)
        {
            var node1 = new TreeNode{Text = "ww"};
            node.Nodes.Add(node1);
        }
    }
}
