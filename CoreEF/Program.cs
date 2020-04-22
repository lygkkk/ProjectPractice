using System;
using CoreEF.Abstract.Models;
using CoreEF.EF;
namespace CoreEF
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInfo userInfo = new UserInfo {Id = new Guid(), Name = "zjh123", Age = 35 };
            //Blog blog = new Blog {BlogId = 1, Url = "www.163.com" };
            SqliteContext sqliteContext = new SqliteContext();
            sqliteContext.Database.EnsureCreatedAsync();
            //sqliteContext.Add(blog);
            sqliteContext.Add(userInfo);
            sqliteContext.SaveChanges();
        }
    }
}
