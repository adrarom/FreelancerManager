using FreelancerManager.Domain.Clients;
using FreelancerManager.Domain.Invoices;
using Xunit;
namespace FreelancerManager.UnitTests.Domain.Invoices
{
    public class InvoicesTests
    {

        private static Client CreateClient()
        {
            return new Client(
                "Acme Ltd",
                "B12345678",
                "contact@acme.com");
        }
        [Fact]
        public void AddLine_WithValidLine_AddsLineToInvoice()
        {
            //Arrange

            var invoice = new Invoice(CreateClient());
            var line = new InvoiceLine("Backend development", 10m, 50m);

            //Act

            invoice.AddLine(line);

            //Assert

            Assert.Single(invoice.Lines);
            Assert.Contains(line, invoice.Lines);
        }
        [Fact]
        public void AddLine_WithNullLine_ThrowsArgumentNullException()
        {
            var invoice = new Invoice(CreateClient());


            Assert.Throws<ArgumentNullException>(() => invoice.AddLine(null!));
        }
        [Fact]

        public void Subtotal_WithMultipleLines_ReturnsSumOfLineSubtotals()
        {
            var invoice = new Invoice(CreateClient());
            var line1 = new InvoiceLine("Backend development", 10m, 50m);
            var line2 = new InvoiceLine("Frontend development", 8m, 40m);

            invoice.AddLine(line1);
            invoice.AddLine(line2);

            var subtotal = invoice.Subtotal;

            Assert.Equal(820m, subtotal);
        }

        [Fact]
        public void Subtotal_WithNoLines_ReturnsZero()
        {
            var invoice = new Invoice(CreateClient());

            Assert.Equal(0m, invoice.Subtotal);
        }

        [Fact]
        public void NewInvoice_HasDraftStatus()
        {

            var invoice = new Invoice(CreateClient());
            Assert.Equal(InvoiceStatus.Draft, invoice.Status);
        }
        [Fact]
        public void Issue_WithLines_ChangesStatusToIssued()
        {
            var invoice = new Invoice(CreateClient());
            var line = new InvoiceLine(
                "Backend development",
                10m,
                50m
                );

            invoice.AddLine(line);

            invoice.Issue();

            Assert.Equal(InvoiceStatus.Issued, invoice.Status);
        }
        [Fact]
        public void Issue_WithoutLines_ThrowsInvalidOperationException()
        {
            var invoice = new Invoice(CreateClient());
            
            Assert.Throws<InvalidOperationException>(() => invoice.Issue());
        }

        [Fact]
        public void Issue_WhenAlreadyIssued_ThrowsInvalidOperationException()
        {
            var invoice = new Invoice(CreateClient());
            var invoiceLine = new InvoiceLine("Backend development", 10m, 50m);

            invoice.AddLine(invoiceLine);
            invoice.Issue();

            Assert.Throws<InvalidOperationException>(() => invoice.Issue());
        }
        [Fact]
        public void AddLine_WhenInvoiceIsIssued_ThrowsInvalidOperationException()
        {
            var invoice = new Invoice(CreateClient());
            var invoiceLine = new InvoiceLine("Backend development", 10m, 50m);

            invoice.AddLine(invoiceLine);
            invoice.Issue();

            Assert.Throws<InvalidOperationException>(() => invoice.AddLine(invoiceLine));
        }

        [Fact]
        public void Constructor_WithValidClient_AssignsClient()
        {
            var client = new Client(
                "Acme Ltd",
                "B12345678",
                "contact@acme.com");

            var invoice = new Invoice(client);

            Assert.Same(client, invoice.Client);
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Invoice(null!));
        }


    }
}
