using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ProjectPractice.FileStream
{
    class Program
    {
        private static Excel.Application application;
        private static List<string[]> sourceList;
        private static List<string[]> resultList;
        static void Main(string[] args)
        {
            
           
            
            application = new Excel.Application();
            
            application.Workbooks.Open(@"C:\Users\Administrator\Desktop\员工信息查看模板1.xlsx");

            sourceList = new List<string[]>();
            //StreamReader streamReader = new StreamReader(@"C:\Users\Administrator\Desktop\大重汇.txt", Encoding.Default);
            sourceList.Add(File.ReadAllLines(@"C:\Users\Administrator\Desktop\大重汇.txt"));

            sourceList.ForEach(x =>
            {
                string pattern = @"—————— \d*  当前账号 |拖 \d* :";
                
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i].Contains("当前账号"))
                    {
                        string str = Regex.Replace(x[i], pattern, string.Empty);
                        string[] str1 = str.Split(' ');
                        //int start = str.IndexOf("号") + 1;
                        //x[i] = str.Substring(start); 
                    }
                }
            });
            

            //Console.WriteLine();
            string deskTopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string folderName = @"\文本汇总";

            string[] filesPath = Directory.GetFiles(deskTopPath + folderName);

            
            foreach (string file in filesPath)
            {
                //System.IO.FileStream fileStream = new System.IO.FileStream("", FileMode.OpenOrCreate, FileAccess.Read);
                //StreamReader streamReader = new StreamReader(file, Encoding.Default);

                sourceList.Add(File.ReadAllLines(file));
            }

            resultList = new List<string[]>();
            foreach (string[] file in sourceList)
            {
                foreach (string line in file)
                {
                    resultList.Add(line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }

        }

        #region 获取指定的进程
        /// <summary>
        /// 获取指定的进程
        /// </summary>
        /// <param name=进程名称></param>
        /// <returns></returns>
        private Process[] GetProcess(string name)
        {
            //Process[] process = Process.GetProcessesByName("Excel");
            Process[] process = Process.GetProcessesByName(name);
            application = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.application");
            return process;
        }
        #endregion

        #region 读取TXT文件内容
        #endregion

    }
}
