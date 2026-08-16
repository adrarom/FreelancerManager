using System;
using System.Collections.Generic;
using System.Text;

namespace FreelancerManager.Domain.Invoices
{
    public class InvoiceLine
    {
        public string Description { get; }
        public decimal Quantity { get; }

        public decimal UnitPrice { get; }

        public decimal Subtotal => UnitPrice * Quantity;

        public InvoiceLine(string description, decimal quantity, decimal unitPrice)
        {
            Description = description;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }


    }
}
