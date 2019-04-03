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

            FileStream = new FileStream(@"C:\Users\Administrator\Desktop\销售出库单明细.xls", FileMode.OpenOrCreate, FileAccess.ReadWrite);
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
