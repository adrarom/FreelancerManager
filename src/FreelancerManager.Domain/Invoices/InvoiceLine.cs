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
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty", nameof(description));
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity),"Quantity must be greater than zero");
            }
            if(unitPrice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(unitPrice),"Unit Price cannot be negative");
            }
            Description = description;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }


    }
}
