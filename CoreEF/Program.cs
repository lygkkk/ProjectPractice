using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CoreEF.Abstract.Models;
using CoreEF.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoreEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var dt = new DataTable();
            var x1 = dt.Compute("(200-12.2)/5", "false");

            Console.WriteLine(x1.ToString());

            //Dictionary<string, Func<int, int>> dic = new Dictionary<string, Func<int, int>>();
            //dic.Add("+", AddCalc);
            //var dd = dic.ContainsKey("-") ? dic["-"](3) : 0;
            //Console.WriteLine(dic["-"](3).ToString());

            DbContextOptions<SqliteContext> dbContext = new DbContextOptions<SqliteContext>();
            //DbContextOptionsBuilder<SqliteContext> optionsBuilder = new DbContextOptionsBuilder<SqliteContext>();
            //optionsBuilder.UseSqlite(@"E:\Code\VS2017\ProjectPractice\ProjectPractice.Sqlite\bin\Debug\lab.db");

            //DbContext db = new DbContext();
            SqliteContext db = new SqliteContext(dbContext);
            UserInfo userInfo = new UserInfo { Id = new Guid().ToString(), Name = "zjh12345" };

            db.UserInfos.Add(userInfo);
            db.Database.EnsureCreatedAsync();
            db.SaveChangesAsync();

            //typeof(Program).Assembly.GetTypes().ToList().ForEach(m => Debug.WriteLine(m.Name));

            //Blog blog = new Blog {BlogId = 1, Url = "www.163.com" };
            //SqliteContext sqliteContext = new SqliteContext();
            //sqliteContext.Database.EnsureCreatedAsync();
            ////sqliteContext.Add(blog);
            //sqliteContext.Add(userInfo);
            //sqliteContext.SaveChanges();
        }

        private static int AddCalc(int t)
        {

            return t + 1;
        }
    }
}
