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
    public class TestContext : DbContext
    {
        public DbSet<ProductInfo> productInfos { get; set; }
        public DbSet<CustomerInfo> customerInfos { get; set; }
        public TestContext() : base("DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<SqliteContext>(modelBuilder));
            modelBuilder.Entity<UserInfo>().HasKey(k => k.Id);
        }
    }
}
