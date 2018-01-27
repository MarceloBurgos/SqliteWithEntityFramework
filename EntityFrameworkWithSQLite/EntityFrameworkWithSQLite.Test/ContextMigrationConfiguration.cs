using System.Data.Entity.Migrations;
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
