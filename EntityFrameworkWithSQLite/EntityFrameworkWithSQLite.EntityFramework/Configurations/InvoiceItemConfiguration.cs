using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntityFrameworkWithSQLite.Core;

namespace EntityFrameworkWithSQLite.EntityFramework.Configurations
{
    public class InvoiceItemConfiguration : EntityTypeConfiguration<InvoiceItem>
    {
        public InvoiceItemConfiguration()
        {
            HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Price).IsRequired();
            Property(x => x.Quantity).IsRequired();
            HasRequired(x => x.Product);
        }
    }
}
