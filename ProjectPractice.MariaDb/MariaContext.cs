using Microsoft.EntityFrameworkCore;
using ProjectPractice.MariaDb.Models;

namespace ProjectPractice.MariaDb
{
    public sealed class MariaContext : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }


        public MariaContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=T1; User=root;Password=123456;");
            
        }
    }
}