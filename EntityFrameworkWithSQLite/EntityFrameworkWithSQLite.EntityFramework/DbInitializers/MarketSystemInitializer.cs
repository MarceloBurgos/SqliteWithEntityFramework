using System.Data.Entity;
using EntityFrameworkWithSQLite.Core;

namespace EntityFrameworkWithSQLite.EntityFramework.DbInitializers
{
    public class MarketSystemInitializer : BaseCustomInitializer
    {
        protected override void Seed(MarketSystemContext context)
        {
            var root = new MarketSystem();
            root.Products.Add(new Product("candy", 1.34m));
            root.Products.Add(new Product("milk", 4.9m));
            root.Products.Add(new Product("cheese", 54.2m));
            root.Products.Add(new Product("cereal", 9.16m));
            root.Products.Add(new Product("ice cream", 7.5m));

            context.MarketSystem.Add(root);
            context.SaveChanges();
        }
    }
}
