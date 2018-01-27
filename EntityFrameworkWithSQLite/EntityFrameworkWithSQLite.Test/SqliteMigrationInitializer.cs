using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EntityFrameworkWithSQLite.Core;
using EntityFrameworkWithSQLite.EntityFramework;

namespace EntityFrameworkWithSQLite.Test
{
    public class SqliteMigrationInitializer : MigrateDatabaseToLatestVersion<MarketSystemContext, ContextMigrationConfiguration>
    {
        private readonly ContextMigrationConfiguration _configuration;

        public SqliteMigrationInitializer(ContextMigrationConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
