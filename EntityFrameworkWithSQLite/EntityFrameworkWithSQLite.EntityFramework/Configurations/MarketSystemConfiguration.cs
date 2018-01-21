using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntityFrameworkWithSQLite.Core;

namespace EntityFrameworkWithSQLite.EntityFramework.Configurations
{
    public class MarketSystemConfiguration : EntityTypeConfiguration<MarketSystem>
    {
        public MarketSystemConfiguration()
        {
            ToTable("MarketSystem");
            HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SystemName).IsRequired();
            HasMany(x => x.Products);
            HasMany(x => x.Invoices);
        }
    }
}
