using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EntityFrameworkWithSQLite.Core;
using EntityFrameworkWithSQLite.EntityFramework.Configurations;
using EntityFrameworkWithSQLite.EntityFramework.Conventions;
using EntityFrameworkWithSQLite.EntityFramework.DbInitializers;

namespace EntityFrameworkWithSQLite.EntityFramework
{
    public class MarketSystemContext : DbContext
    {
        private readonly IDatabaseInitializer<MarketSystemContext> _initializer;
        public virtual DbSet<MarketSystem> MarketSystem { get; set; }
        
        public MarketSystemContext()
            : base("MarketSystemDb")
        {
            _initializer = new MarketSystemInitializer();
        }

        public MarketSystemContext(DbConnection connection, IDatabaseInitializer<MarketSystemContext> initializer)
            : base(connection, false)
        {
            _initializer = initializer;
            //Database.SetInitializer(initializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new ForeignKeyNamingConvention());

            modelBuilder.Configurations.Add(new MarketSystemConfiguration());
            modelBuilder.Configurations.Add(new InvoiceConfiguration());
            modelBuilder.Configurations.Add(new InvoiceItemConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());

            Database.SetInitializer(_initializer);
        }
    }
}
