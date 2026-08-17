using FreelancerManager.Domain.Clients;

namespace FreelancerManager.Application.Invoices.CreateInvoice;

public record CreateInvoiceRequest(
    Client Client,
    IReadOnlyCollection<CreateInvoiceLineRequest> Lines);