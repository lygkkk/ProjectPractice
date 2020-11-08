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

            

        }

        #region 写入文本文档
        public void WriteTXT()
        {
            string path = @"C:\Users\Administrator\Desktop\2.txt";

            using (System.IO.FileStream fs = File.Create(path))
            {
                //byte[] info = new UTF8Encoding(true).GetBytes("测试测试");
                byte[] info = Encoding.UTF8.GetBytes("测试一下");
                fs.Write(info, 0, info.Length);
            }
        }
        #endregion

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
