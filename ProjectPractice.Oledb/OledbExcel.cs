﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectPractice.Oledb
{
    public class OledbExcel
    {
        private static OleDbConnection Oledb { get; set; }
        private static string DataBase { get; set; }
        private static string Provider { get; set; }
        public OledbExcel(string dataBase)
        {
            DataBase = dataBase;
        }

        public async Task Select1Async(string sql)
        {
            var conn = new OleDbConnection();
            var comm = conn.CreateCommand();
            comm.CommandText = sql;
            
            var tb = new System.Data.DataTable();
            tb.Load(await comm.ExecuteReaderAsync());
        }
        public async Task<System.Data.DataTable> SelectDataTableAsync(string sql)
        {
            Provider = @"Provider=Microsoft.Ace.OleDb.12.0;Extended Properties=Excel 12.0;Data Source=";
            //DataBase = @"C:\Users\Administrator\Desktop\表格.xlsx";
            //Oledb = new OleDbConnection(Provider + DataBase);
            System.Data.DataTable dt = new System.Data.DataTable();

            await Task.Run(() =>
            {
                using (OleDbConnection oleDb = new OleDbConnection(Provider + DataBase)) 
                {
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                    {
                        dataAdapter.SelectCommand = new OleDbCommand(sql);
                        dataAdapter.SelectCommand.Connection = oleDb;
                        dataAdapter.Fill(dt);
                        //获取第一列
                        //var arr = dt.AsEnumerable().Select(e => e.Field<string>("Name")).ToArray();
                    }
                }
                
            });
            return dt;
        }

        public async Task<OleDbDataAdapter> DataAdapterAsync(string sql)
        {
            Provider = @"Provider=Microsoft.Ace.OleDb.12.0;Extended Properties=Excel 12.0;Data Source=";
            //DataBase = @"C:\Users\Administrator\Desktop\表格.xlsx";
            //Oledb = new OleDbConnection(Provider + DataBase);
            OleDbDataAdapter dp = null;

            await Task.Run(() =>
            {
                using (OleDbConnection oleDb = new OleDbConnection(Provider + DataBase))
                {
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                    {
                        dp = new OleDbDataAdapter();
                        dataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM [Sheet1$]");
                        dataAdapter.SelectCommand.Connection = oleDb;

                        dp = dataAdapter;
                    }
                }

            });
            return dp;
        }

        public OleDbDataAdapter DataAdapter(string sql)
        {
            Provider = @"Provider=Microsoft.Ace.OleDb.12.0;Extended Properties=Excel 12.0;Data Source=";
            //DataBase = @"C:\Users\Administrator\Desktop\表格.xlsx";
            //Oledb = new OleDbConnection(Provider + DataBase);
            OleDbDataAdapter dp = null;

                using (OleDbConnection oleDb = new OleDbConnection(Provider + DataBase))
                {
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                    {
                        dp = new OleDbDataAdapter();
                        dataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM [Sheet1$]");
                        dataAdapter.SelectCommand.Connection = oleDb;

                        dp = dataAdapter;
                    }
                }

            return dp;
        }
        public System.Data.DataTable Select(string sql)
        {
            Provider = @"Provider=Microsoft.Ace.OleDb.12.0;Extended Properties=Excel 12.0;Data Source=";
            //DataBase = @"C:\Users\Administrator\Desktop\表格.xlsx";
            //Oledb = new OleDbConnection(Provider + DataBase);
            System.Data.DataTable dt = new System.Data.DataTable();
            using (OleDbConnection oleDb = new OleDbConnection(Provider + DataBase))
            {
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                {
                    dataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM [Sheet1$]");
                    dataAdapter.SelectCommand.Connection = oleDb;
                    DataSet ds1 = new DataSet();
                    dataAdapter.Fill(dt);
                    //获取第一列
                    //var arr = dt.AsEnumerable().Select(e => e.Field<string>("Name")).ToArray();
                }
            }
            return dt;
        }

        public IQueryable<System.Data.DataTable> GetDataTables<T1, T2>(Expression<Func<T1, T2>> pre)
        {
            pre.ToString();
            return null;
        }
    }
}