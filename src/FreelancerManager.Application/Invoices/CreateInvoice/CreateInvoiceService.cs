using FreelancerManager.Domain.Invoices;

namespace FreelancerManager.Application.Invoices.CreateInvoice
{
    public class CreateInvoiceService
    {
        public Invoice Execute(CreateInvoiceRequest request)
        {

            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(request.Lines);

            var invoice = new Invoice(request.Client);
            
            foreach (var line in request.Lines)
            {
                var invoiceLine = new InvoiceLine(
                    line.Description,
                    line.Quantity,
                    line.UnitPrice);

                invoice.AddLine(invoiceLine);
            }

            return invoice;

        }
    }
}
