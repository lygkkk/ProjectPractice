using ProjectPractice.Sqlite.Abstract.Models;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Sqlite.EF
{
    public class SqliteContext :DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }
        public SqliteContext() : base("DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<SqliteContext>(modelBuilder));
            //modelBuilder.Entity<UserInfo>().Property(d => d.Id).HasColumnType("text");
        }
    }
}
