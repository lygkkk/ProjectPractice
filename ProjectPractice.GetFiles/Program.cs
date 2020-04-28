using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace ProjectPractice.GetFiles
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IEnumerable<string> filesList = new List<string>();
            string p = @"C:\Users\Administrator\Desktop\20年";
            //filesList = Directory.GetFiles(@"C:\Users\Administrator\Desktop\20年", "*.xlsx", SearchOption.AllDirectories);
            filesList = Directory.GetDirectories(@"C:\Users\Administrator\Desktop\20年", "*", SearchOption.AllDirectories);

            

        }

        private static IEnumerable<string> GetAllFiles(string path)
        {
            List<string> list = new List<string>();
            string[] directories = Directory.GetDirectories(path);

            if (directories.Length > 0)
            {
                foreach (string item in directories)
                {
                    list.AddRange(GetAllFiles(item));
                }
            }
            list.AddRange(Directory.GetFiles(path));
            return list;
        }
    }
}
