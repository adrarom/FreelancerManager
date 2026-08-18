using FreelancerManager.Domain.Clients;

namespace FreelancerManager.Domain.Invoices
{
    public class Invoice
    {
        public Guid Id { get; private set; }
        private readonly List<InvoiceLine> _lines = [];

        public Client Client { get; }

        public IReadOnlyCollection<InvoiceLine> Lines => _lines.AsReadOnly();

        public decimal Subtotal => _lines.Sum(line => line.Subtotal);

        public InvoiceStatus Status { get; private set; } = InvoiceStatus.Draft;

        public Invoice(Client client)
        {
            if(client is null) throw new ArgumentNullException(nameof(client));
            Client = client;
            Id = Guid.NewGuid();
        }
        public void AddLine(InvoiceLine line)
        {
            if (Status != InvoiceStatus.Draft)
            {
                throw new InvalidOperationException("Cannot add lines when Invoice is not at Draft");
            }
            if(line is null) throw new ArgumentNullException(nameof(line),"InvoiceLine can't be null");
            _lines.Add(line);
        }

        public void Issue()
        {
            if (_lines.Count <= 0)
            {
                throw new InvalidOperationException("Invoice cannot be issued without lines.");
            }

            if (Status != InvoiceStatus.Draft)
            {
                throw new InvalidOperationException(
                    "Only draft invoices can be issued.");
            }
            Status = InvoiceStatus.Issued;
        }

        
    }
}
