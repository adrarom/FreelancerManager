using System;
using System.Collections.Generic;
using System.Text;

namespace FreelancerManager.Application.Invoices.CreateInvoice;

public record CreateInvoiceLineRequest(
    string Description,
    decimal Quantity,
    decimal UnitPrice);
