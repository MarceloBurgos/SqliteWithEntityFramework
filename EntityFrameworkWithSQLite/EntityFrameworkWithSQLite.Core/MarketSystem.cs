using System;
using System.Collections.Generic;

namespace EntityFrameworkWithSQLite.Core
{
    public class MarketSystem
    {
        public Guid Id { get; set; }
        public string SystemName { get; set; }
        public virtual IList<Invoice> Invoices { get; set; }
        public virtual IList<Product> Products { get; set; }

        public MarketSystem()
        {
            SystemName = "MarketSystem";
            Invoices = new List<Invoice>();
            Products = new List<Product>();
        }
    }
}
