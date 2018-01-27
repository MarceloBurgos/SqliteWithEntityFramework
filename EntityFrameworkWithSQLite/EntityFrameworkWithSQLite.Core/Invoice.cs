using System;
using System.Collections.Generic;

namespace EntityFrameworkWithSQLite.Core
{
    public class Invoice
    {
        public Guid Id { get; protected set; }
        public string Number { get; set; }
        public DateTime SellDate { get; set; }
        public string Customer { get; set; }
        public IList<InvoiceItem> Items { get; set; }

        protected Invoice()
        {
        }

        public Invoice(string number, DateTime sellDate, string customer)
        {
            Id = Guid.NewGuid();
            Number = number;
            SellDate = sellDate;
            Customer = customer;
            Items = new List<InvoiceItem>();
        }
    }
}
