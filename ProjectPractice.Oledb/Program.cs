using System;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ProjectPractice.Oledb
{
    class Program
    {
        [STAThread]
        static async Task Main(string[] args)
        {

            OledbExcel oledb = new OledbExcel(@"C:\Users\Administrator\Desktop\222.xls");

            var dt = oledb.SelectDataTableAsync("SELECT MONTH(出厂时间), DAY(出厂时间), 车牌号, 交货量 FROM [222$]").Result;

            Console.WriteLine("请按下Enter键后选择XML所在的文件夹");
            ConsoleKeyInfo Key = Console.ReadKey();
            while (Key.Key != ConsoleKey.Enter)
            {
                Key = Console.ReadKey();
            }

            FolderBrowserDialog fdDialog = new FolderBrowserDialog();
            fdDialog.SelectedPath = Directory.GetCurrentDirectory();
            if (fdDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var path = fdDialog.SelectedPath;

            //var path = await GetPath();
            if (string.IsNullOrEmpty(path)) return;

            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            //声明Func委托数组
            //Func < string, string,  Task<DataTable>>[] func = new Func<string, string, Task<DataTable>>[files.Length];
            Func<string, string, DataTable>[] func = new Func<string, string, DataTable>[files.Length];



            IAsyncResult[] results = new IAsyncResult[files.Length];

            //Func委托添加方法 并开始调用
            //for (int i = 0; i < files.Length; i++)
            //{
            //    func[i] =  (dataBase, sql) =>
            //    {
            //        var ole1 = new OledbExcel(dataBase);
            //        var dt =  ole1.Select(sql);
            //        return dt;
            //    };
            //    results[i] = func[i].BeginInvoke(files[i], "SELECT * FROM [sheet1$]", null, null);
            //}

            //for (int i = 0; i < results.Length; i++)
            //{
            //    while (results[i].CompletedSynchronously)
            //    { }
            //    var dt = func[i].EndInvoke(results[i]);

            //    if (dt.Rows.Count > 0)
            //    {
            //        Console.WriteLine("{1}   已经读取完成文件：{0}", files[i], i + 1);
            //        WriteExcel($@"C:\Users\Administrator\Desktop\进销项汇总结果\{Path.GetFileNameWithoutExtension(files[i])}.xlsx", dt);
            //    }
            //    else
            //    {
            //        Console.WriteLine("{1}   出现异常文件：{0}", files[i], i + 1);
            //    }
            //}


            //IAsyncResult


            //Console.WriteLine("开始执行第一个");
            //var db1 = @"C:\Users\Administrator\Desktop\进销项汇总结果\进项\松马进项.xlsx";
            //var ole1 = new OledbExcel(db1);
            //var dt = await ole1.SelectDataTableAsync("");
            ////var dt = await SelectAsync(db1);
            //Console.WriteLine("开始执行第二个");
            //var db2 = @"C:\Users\Administrator\Desktop\进销项汇总结果\销项格式一\松马销项(格式一).xlsx";
            //var ole2 = new OledbExcel(db2);
            //var dt2 = await ole2.SelectDataTableAsync("");
            ////var dt2 = await SelectAsync(db2);

            //Console.WriteLine(dt.Rows.Count);
            //Console.WriteLine(dt2.Rows.Count);
            //Console.WriteLine("到底了");
        }

        #region NPOI写入Excel
        /// <summary>
        /// NPOI写入Excel
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="dataTable">DataTable</param>
        private static void WriteExcel(string path, DataTable dataTable)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            IRow row = null;
            //在第一行的第一列创建单元格
            ICell cell = null;

            int lastRow = dataTable.Rows.Count;
            int lastCol = dataTable.Columns.Count;

            //设置标题
            row = sheet.CreateRow(0);//excel第一行设为标题
            for (int c = 0; c < lastCol; c++)
            {
                cell = row.CreateCell(c);
                cell.SetCellValue(dataTable.Columns[c].ColumnName);
            }

            //设置每行每列的单元格,
            for (int i = 0; i < lastRow; i++)
            {
                row = sheet.CreateRow(i + 1);
                for (int j = 0; j < lastCol; j++)
                {
                    cell = row.CreateCell(j);//excel第二行开始写入数据
                    cell.SetCellValue(dataTable.Rows[i][j].ToString());
                }
            }
            using (var fs = File.OpenWrite(path))
            {
                workbook.Write(fs);//向打开的这个xlsx文件中写入数据
                //result = true;
            }
        }
        #endregion


        #region 获取指定文件夹路径
        /// <summary>
        /// 获取指定文件夹路径
        /// </summary>
        /// <returns></returns>
        [STAThread]
        private static  string GetPath()
        {
            FolderBrowserDialog fdDialog = new FolderBrowserDialog();
            fdDialog.SelectedPath =  Directory.GetCurrentDirectory();
            if (fdDialog.ShowDialog() != DialogResult.OK)
            {
                return "";
            }
            return fdDialog.SelectedPath;
        }

        #endregion
        

        //static async Task<DataTable> SelectAsync(string db1)
        //{
        //    var ole1 = new OledbExcel(db1);
        //    DataTable dt = new DataTable();
        //    await Task.Run(() => dt = ole1.Select1(""));
        //    return dt;
        //}
        //static async Task WritExcel(DataTable dataTable)
        //{
            //foreach (DataRow item in dt.Rows)
            //{
            //    foreach (var item1 in item.ItemArray)
            //    {

            //    }
            //}


            //object[,] result = new object[53,8];

            //int row = 0;
            //int col = 0;
            //string[] tmp;

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        if (dt.Rows[i][j].ToString().Length > 13)
            //        {
            //            tmp = dt.Rows[i][j].ToString().Split('；');

            //        }
            //        result[i, j] = dt.Rows[i][j];
            //    }
            //}

            //Excel.Application app = (Excel.Application) Marshal.GetActiveObject("excel.application");
            //app.Range["g2"].Resize[18, 1].Value = result;
        //}


    }
}
