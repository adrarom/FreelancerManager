namespace FreelancerManager.Domain.Invoices
{
    public class Invoice
    {
        private readonly List<InvoiceLine> _lines = [];

        public IReadOnlyCollection<InvoiceLine> Lines => _lines.AsReadOnly();

        public decimal Subtotal => _lines.Sum(line => line.Subtotal);

        public InvoiceStatus Status { get; private set; } = InvoiceStatus.Draft;
        public void AddLine(InvoiceLine line)
        {
            if(line is null) throw new ArgumentNullException(nameof(line),"InvoiceLine can't be null");
            _lines.Add(line);
        }

        public void Issue()
        {
            if (_lines.Count <= 0)
            {
                throw new InvalidOperationException("Invoice cannot be issued without lines.");
            }

            if (Status == InvoiceStatus.Issued) 
            {
                throw new InvalidOperationException("Invoice status is already Issued");
            }
            Status = InvoiceStatus.Issued;
        }
    }
}
