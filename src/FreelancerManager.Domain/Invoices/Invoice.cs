namespace FreelancerManager.Domain.Invoices
{
    public class Invoice
    {
        private readonly List<InvoiceLine> _lines = [];

        public IReadOnlyCollection<InvoiceLine> Lines => _lines.AsReadOnly();

        public decimal Subtotal => _lines.Sum(line => line.Subtotal);

        public void AddLine(InvoiceLine line)
        {
            if(line is null) throw new ArgumentNullException(nameof(line),"InvoiceLine can't be null");
            _lines.Add(line);
        }
    }
}
