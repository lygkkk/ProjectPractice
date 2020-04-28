using ProjectPractice.Sqlite.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Sqlite
{
    public class Configuration : DbMigrationsConfiguration<TestContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }

        protected override void Seed(TestContext context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

            //context.Employees
            //       .AddOrUpdate(p => p.Name,
            //                    new Employee {Name = "Andrew Peters"},
            //                    new Employee {Name = "Brice Lambson"},
            //                    new Employee {Name = "Rowan Miller"}
            //                   );
        }
    }
}
