using System;

namespace EntityFrameworkWithSQLite.Core
{
    public class InvoiceItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }

        protected InvoiceItem()
        {
        }

        public InvoiceItem(int quatity, decimal price, Product product)
        {
            Id = Guid.NewGuid();
            Quantity = quatity;
            Price = price;
            Product = product;
        }
    }
}