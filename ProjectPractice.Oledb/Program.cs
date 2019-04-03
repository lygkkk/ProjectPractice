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
            DataBase = @"C:\Users\Administrator\Desktop\工作簿1.xlsx";
            Provider = @"Provider=Microsoft.Ace.OleDb.12.0;Extended Properties=Excel 12.0;Data Source=";
            Oledb = new OleDbConnection(Provider + DataBase);

            DataTable dt = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                dataAdapter.SelectCommand = new OleDbCommand("SELECT qqq FROM [Sheet1$]");
                dataAdapter.SelectCommand.Connection = Oledb;
                dataAdapter.Fill(dt);
            }

            object[,] result = new object[18,1];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result[i,0] = dt.Rows[i][2];
            }

            Excel.Application app = (Excel.Application) Marshal.GetActiveObject("excel.application");
            app.Range["g2"].Resize[18, 1].Value = result;

        }
    }
}
