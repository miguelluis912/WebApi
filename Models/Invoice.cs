using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            Invoicelines = new HashSet<Invoiceline>();
        }

        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? BillingAddress { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingCountry { get; set; }
        public string? BillingPostalCode { get; set; }
        public decimal Total { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Invoiceline> Invoicelines { get; set; }
    }
}
