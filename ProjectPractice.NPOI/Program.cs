using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq.Expressions;
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


            ReadExcel();

            //GetAllData((sheet, dt) => { dt.NewRow(); });

            //FileStream = File.OpenRead(@"C:\Users\Administrator\Desktop\单据审核中心.xlsx");
            //Workbook = new XSSFWorkbook(FileStream);
            //Sheet = Workbook.GetSheet("单据审核中心");
            //LastRow = Sheet.LastRowNum;

            //string[,] str = new string[1, LastRow];
            //for (int i = 1; i < LastRow; i++)
            //{
            //    Row = Sheet.GetRow(i);
            //    //_list.Add();
            //}
        }

        #region 获取单元格值类型
        /// <summary>
        /// 获取单元格值类型
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="dataRow"></param>
        /// <param name="columnNum"></param>
        private void GetCellType(ICell cell, DataRow dataRow, int columnNum)
        {
            //try
            //{
            //    switch (cell.CellType)
            //    {
            //        case CellType.String:
            //            dataRow[columnNum] = cell.StringCellValue;
            //            break;
            //        case CellType.Numeric:
            //            if (DateUtil.IsCellDateFormatted(cell))
            //            {
            //                dataRow[columnNum] = cell.DateCellValue;
            //            }
            //            else
            //            {
            //                dataRow[columnNum] = cell.NumericCellValue;
            //            }
            //            break;

            //        default:
            //            dataRow[columnNum] = "";
            //            break;
            //    }
            //}
            //catch (Exception e)
            //{ }
        }
        #endregion

        #region 单元格样式
        public static ICellStyle GetCellStyle(IndexedColors indexedColor)
        {
            ICellStyle style = Workbook.CreateCellStyle();
            style.FillForegroundColor = indexedColor.Index;
            style.FillPattern = FillPattern.SolidForeground;
            return style;
        }
        #endregion

        #region 写入文件
        private static void WriteExcel()
        {
            Workbook = new XSSFWorkbook();

            Sheet = Workbook.CreateSheet("Sheet1");

            Row = Sheet.CreateRow(0);
            Row.CreateCell(0).CellStyle = GetCellStyle(IndexedColors.Blue);

            using (FileStream file = new FileStream(@"C:\Users\Administrator\Desktop\123.xlsx", FileMode.OpenOrCreate, FileAccess.Write))
            {
                Workbook.Write(file);
            }
        }
        #endregion

        #region 读取文件
        private static void ReadExcel()
        {
            using (FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\新建 Microsoft Excel 工作表.xlsx", FileMode.OpenOrCreate))
            {
                Workbook = new XSSFWorkbook(fs);
                Sheet = Workbook.GetSheetAt(0);
                //var x = Sheet.ShiftRows()
                for (int i = 0; i <= Sheet.LastRowNum; i++)
                {
                    Row = Sheet.GetRow(i);
                    if (Row == null) continue;
                    for (int j = 0; j < Row.LastCellNum; j++)
                    {
                        Console.WriteLine(Row.GetCell(j)?.ToString());
                    }
                }
            }


        }
        #endregion
    }
}
