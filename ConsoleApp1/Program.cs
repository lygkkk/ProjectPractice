using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Abstract.Models;
using System.Windows.Forms;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> files = new List<string>();
            files.Add(@"C:\Users\Administrator\Desktop\技术分享读取13000个XML文件程序");

            //
            var x1 = Directory.GetFiles(@"C:\Users\Administrator\Desktop\技术分享读取13000个XML文件程序", "*.cs", SearchOption.AllDirectories);


            var x2 = Directory.GetDirectories(@"C:\Users\Administrator\Desktop\技术分享读取13000个XML文件程序", "*", SearchOption.AllDirectories);

            string[] directories = Directory.GetDirectories(@"C:\Users\Administrator\Desktop\技术分享读取13000个XML文件程序");
            files.AddRange(directories);
            
            var assembly = Assembly.GetAssembly(typeof(File));
            //var classInstance = assembly.CreateInstance(assembly.GetTypes()[0].FullName);
            var methodInfo = assembly.GetType().GetMethods();

            var tmp = Enumerable.Range(1, 100);
            List<int> x = new List<int>();
            var tmp1 = tmp.GroupBy(e =>
            {
                x.Add(e % 5);
                return e % 5;
            });
            foreach (var item in tmp1)
            {
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1);
                }
            }
        }

        
    }

   
}
