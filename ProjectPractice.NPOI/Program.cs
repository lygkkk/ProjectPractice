using System;
using System.Collections.Generic;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.Streaming;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.Util;

namespace ProjectPractice.NPOI
{
    class Program
    {
        private static IWorkbook Workbook { get; set; }
        private static ISheet Sheet { get; set; }
        private static IRow Row { get; set; }

        private static FileStream FileStream { get; set; }
        private static int LastRow { get; set; }
        static void Main(string[] args)
        {

            FileStream = File.OpenRead(@"C:\Users\Administrator\Desktop\数据筛选之多种方法效率.xlsx");
            Workbook = new XSSFWorkbook(FileStream);
            Sheet = Workbook.GetSheet("Sheet1");
            LastRow = Sheet.LastRowNum;

            string[,] str = new string[1, LastRow];
            for (int i = 1; i < LastRow; i++)
            {
                Row = Sheet.GetRow(i);
                //_list.Add();
            }
            


            


        }

        private static void GetAllData()
        {

        }
    }
}
