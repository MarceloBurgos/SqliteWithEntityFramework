using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using EntityFrameworkWithSQLite.Core;
using EntityFrameworkWithSQLite.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityFrameworkWithSQLite.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void CreateProductWithValidValues_ShouldPersist()
        {
            //using (var connection = new SQLiteConnection("data source=:memory:"))
            using (var connection = new SQLiteConnection("data source=MarketDB.sqlite3"))
            {
                connection.Open();
                var sqliteInitilizer = new MigrateDatabaseToLatestVersion<MarketSystemContext, ContextMigrationConfiguration>(true);

                using (var context = new MarketSystemContext(connection, sqliteInitilizer))
                {
                    context.Database.Initialize(true);

                    var root = new MarketSystem();
                    root.Products.Add(new Product("candy", 1.34m));
                    root.Products.Add(new Product("milk", 4.9m));
                    root.Products.Add(new Product("cheese", 54.2m));
                    root.Products.Add(new Product("cereal", 9.16m));
                    root.Products.Add(new Product("ice cream", 7.5m));

                    context.MarketSystem.Add(root);
                    context.SaveChanges();

                    var products = context.MarketSystem.First().Products;
                    products.Add(new Product("coffee", 6.07m));
                    context.SaveChanges();
                }
            }
        }
    }
}
