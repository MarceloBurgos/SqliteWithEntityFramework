using System;

namespace EntityFrameworkWithSQLite.Core
{
    public class Product
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        protected Product()
        {
        }

        public Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }
    }
}