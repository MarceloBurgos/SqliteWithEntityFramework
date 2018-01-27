using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using EntityFrameworkWithSQLite.Core;
using EntityFrameworkWithSQLite.EntityFramework;
using EntityFrameworkWithSQLite.Test.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityFrameworkWithSQLite.Test
{
    [TestClass]
    public class ProductTest
    {
        private static string schemaQuery;
        private SQLiteConnection _connection;
        private MarketSystem _root;
        private MarketSystemContext _context;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            using (var connection = new SQLiteConnection("data source=:memory:"))
            {
                connection.Open();

                var configuration = new ContextMigrationConfiguration();
                var sqliteInitilizer = new MigrateDatabaseToLatestVersion<MarketSystemContext, ContextMigrationConfiguration>(true, configuration);

                var context = new MarketSystemContext(connection, sqliteInitilizer);
                context.Database.Initialize(true);

                var generator = (SQLiteMigrationSqlGenerator)configuration.GetSqlGenerator("System.Data.SQLite");
                schemaQuery = string.Join("; \n\r", generator.MigrationStatements.Select(x => x.Sql));
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _root = new MarketSystem();

            _connection = new SQLiteConnection("data source=:memory:");
            _connection.Open();

            _context = new MarketSystemContext(_connection, null);

            var comm = _connection.CreateCommand();
            comm.CommandText = schemaQuery;
            comm.ExecuteNonQuery();

            _context.MarketSystem.Add(_root);
            _context.SaveChanges();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _connection.Close();
            _context.Dispose();
        }

        [TestMethod]
        public void AddProduct_ShouldPersist()
        {
            var product = new Product("coca cola", 25);
            _root.Products.Add(product);
            _context.SaveChanges();

            var newProduct = _context.Database.SqlQuery<Product>("select * from Product").ToList();
            Assert.AreEqual(1, newProduct.Count);
        }

        [TestMethod]
        public void AddInvoice_ShouldPersist()
        {
            var product = new Product("pepsi", 25);
            _root.Products.Add(product);
            _context.SaveChanges();

            var invoice = new Invoice("inv-1", DateTime.Now, "sovos");
            invoice.Items.Add(new InvoiceItem(3, 28, product));
            _root.Invoices.Add(invoice);
            _context.SaveChanges();

            var newProduct = _context.Database.SqlQuery<Product>("select * from Product");
            Assert.AreEqual(1, newProduct.Count());

            var newInvoice = _context.Database.SqlQuery<Invoice>("select * from Invoice");
            Assert.AreEqual(1, newInvoice.Count());
        }

        //[TestMethod]
        public void CreateProductWithValidValues_ShouldPersist()
        {
            using (var connection = new SQLiteConnection("data source=:memory:"))
            //using (var connection = new SQLiteConnection("data source=MarketDB.sqlite3"))
            {
                connection.Open();

                var configuration = new ContextMigrationConfiguration();
                var sqliteInitilizer = new MigrateDatabaseToLatestVersion<MarketSystemContext, ContextMigrationConfiguration>(true, configuration);
                //var sqliteInitilizer = new SqliteMigrationInitializer(configuration);

                using (var context = new MarketSystemContext(connection, sqliteInitilizer))
                {
                    context.Database.Log = message =>
                    {
                        var file = File.AppendText("logfile.txt");
                        file.WriteLine($"{DateTime.Now} - {message}");
                        file.Close();
                    };

                    //sqliteInitilizer.InitializeDatabase(context);
                    context.Database.Initialize(true);
                    //var generator = (SQLiteMigrationSqlGenerator)configuration.GetSqlGenerator("System.Data.SQLite");

                    //var comm = connection.CreateCommand();
                    //comm.CommandText = string.Join("; \n\r", generator.MigrationStatements.Select(x => x.Sql));
                    //comm.ExecuteNonQuery();

                    var root = new MarketSystem();
                    root.Products.Add(new Product("candy", 1.34m));
                    root.Products.Add(new Product("milk", 4.9m));
                    root.Products.Add(new Product("cheese", 54.2m));
                    root.Products.Add(new Product("cereal", 9.16m));
                    root.Products.Add(new Product("ice cream", 7.5m));

                    context.MarketSystem.Add(root);
                    context.SaveChanges();

                    var market = context.MarketSystem.First();

                    var products = context.MarketSystem.First().Products;
                    products.Add(new Product("coffee", 6.07m));
                    context.SaveChanges();
                }
            }
        }
    }
}
