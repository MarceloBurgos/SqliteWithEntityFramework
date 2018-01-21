using System.Data.Entity;

namespace EntityFrameworkWithSQLite.EntityFramework.DbInitializers
{
    public abstract class BaseCustomInitializer : DropCreateDatabaseAlways<MarketSystemContext>
    {
        public DbModelBuilder ModelBuilder { get; set; }
    }
}