using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjectPractice.Oledb
{
    class Program
    {
        private static OleDbConnection Oledb { get; set; }
        private static string DataBase { get; set; }
        private static string Provider { get; set; }

        static void Main(string[] args)
        {
            DataBase = @"C:\Users\Administrator\Desktop\表格.xlsx";
            Provider = @"Provider=Microsoft.Ace.OleDb.12.0;Extended Properties=Excel 12.0;Data Source=";
            Oledb = new OleDbConnection(Provider + DataBase);

            DataTable dt = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                dataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM [Sheet1$]");
                dataAdapter.SelectCommand.Connection = Oledb;
                dataAdapter.Fill(dt);
                //获取第一列
                //var arr = dt.AsEnumerable().Select(e => e.Field<string>("Name")).ToArray();
            }
            foreach (DataRow item in dt.Rows)
            {
                foreach (var item1 in item.ItemArray)
                {

                }
            }
            

            object[,] result = new object[53,8];

            int row = 0;
            int col = 0;
            string[] tmp;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j].ToString().Length > 13)
                    {
                        tmp = dt.Rows[i][j].ToString().Split('；');

                    }
                    result[i, j] = dt.Rows[i][j];
                }
            }

            Excel.Application app = (Excel.Application) Marshal.GetActiveObject("excel.application");
            app.Range["g2"].Resize[18, 1].Value = result;

        }
    }
}
