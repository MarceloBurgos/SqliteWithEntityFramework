using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntityFrameworkWithSQLite.Core;

namespace EntityFrameworkWithSQLite.EntityFramework.Configurations
{
    public class InvoiceConfiguration : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfiguration()
        {
            HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Number).IsRequired();
            Property(x => x.SellDate).IsRequired();
            Property(x => x.Customer).IsRequired();
            HasMany(x => x.Items);
        }
    }
}
