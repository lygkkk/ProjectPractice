using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CoreEF.Abstract.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreEF.EF
{
    public class SqliteContext :DbContext
    {
        //public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        //public DbSet<Post> Posts { get; set; }
        //public SqliteContext(DbContextOptions<SqliteContext> options) : base (options)
        //{ 
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=h:\test.db");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne();
            //modelBuilder.
            //modelBuilder.Entity<UserInfo>().ToTable("UserInfo", "test");
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<UserInfo>().HasKey(u => u.Id);
            //modelBuilder.Entity<Blog>().HasKey(u => u.BlogId);
        }
    }
}
