using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkWithSQLite.Core;
using EntityFrameworkWithSQLite.EntityFramework;
using EntityFrameworkWithSQLite.Test.Migrations;

namespace EntityFrameworkWithSQLite.Test
{
    public class ContextMigrationConfiguration : DbMigrationsConfiguration<MarketSystemContext>
    {
        public ContextMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }
    }
}
