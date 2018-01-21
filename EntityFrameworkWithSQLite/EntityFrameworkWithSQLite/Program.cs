using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkWithSQLite.Core;
using EntityFrameworkWithSQLite.EntityFramework;

namespace EntityFrameworkWithSQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Market's products");
            Console.WriteLine("-----------------");

            var context = new MarketSystemContext();
            context.Database.Initialize(true);

            var products = context.MarketSystem.First().Products;

            foreach (var item in products)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}");
            }

            Console.ReadKey();
        }
    }
}
