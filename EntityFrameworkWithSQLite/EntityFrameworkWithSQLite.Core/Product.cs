using System;

namespace EntityFrameworkWithSQLite.Core
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        protected Product()
        {
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}