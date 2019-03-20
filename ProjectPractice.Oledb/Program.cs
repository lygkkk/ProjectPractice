using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace ProjectPractice.Oledb
{
    class Program
    {
        private static OleDbConnection Oledb { get; set; }
        private static string DataBase { get; set; }
        private static string Provider { get; set; }

        static void Main(string[] args)
        {
            DataBase = @"C:\Users\Administrator\Desktop\数据筛选之多种方法效率.xlsx";
            Provider = @"Provider=Microsoft.Ace.OleDb.12.0;Extended Properties=Excel 12.0;Data Source=";
            Oledb = new OleDbConnection(Provider + DataBase);

            DataTable dt = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                dataAdapter.SelectCommand = new OleDbCommand("SELECT 数据1, 数据2 FROM [Sheet1$]");
                dataAdapter.SelectCommand.Connection = Oledb;
                dataAdapter.Fill(dt);
            }


        }
    }
}
