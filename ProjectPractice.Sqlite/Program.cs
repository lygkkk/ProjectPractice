using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPractice.Sqlite.Abstract.Models;
using ProjectPractice.Sqlite.EF;

namespace ProjectPractice.Sqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            SqliteContext sqliteContext = new SqliteContext();
            UserInfo userInfo = new UserInfo { Id = Guid.NewGuid().ToString(), Name = "lygkkk12" };
            //新增
            sqliteContext.UserInfos.Add(userInfo);
            sqliteContext.SaveChanges();

            //修改
            //sqliteContext.UserInfos.Attach(userInfo);
            //sqliteContext.Entry(userInfo).State = System.Data.Entity.EntityState.Modified;

            ////删除
            //sqliteContext.Entry(userInfo).State = System.Data.Entity.EntityState.Deleted;
        }
    }
}
