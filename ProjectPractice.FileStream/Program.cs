using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjectPractice.FileStream
{
    class Program
    {
        private static Excel.Application application;
        private static List<string[]> sourceList;
        private static List<string[]> resultList;
        static void Main(string[] args)
        {
            //Console.WriteLine();
            string deskTopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string folderName = @"\文本汇总";

            string[] filesPath = Directory.GetFiles(deskTopPath + folderName);

            sourceList = new List<string[]>();
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
    }
}
