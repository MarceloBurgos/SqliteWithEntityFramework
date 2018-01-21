using System;
using System.Collections.Generic;

namespace EntityFrameworkWithSQLite.Core
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime SellDate { get; set; }
        public string Customer { get; set; }
        public IList<InvoiceItem> Items { get; set; }

        public Invoice()
        {
            Items = new List<InvoiceItem>();
        }
    }
}
