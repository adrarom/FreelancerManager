

using FreelancerManager.Application.Invoices.CreateInvoice;
using FreelancerManager.Domain.Clients;
using FreelancerManager.Domain.Invoices;

namespace FreelancerManager.UnitTests.Application.Invoices.CreateInvoice
{
    public class CreateInvoiceServiceTests
    {
        private static Client CreateClient()
        {
            return new Client(
                "Acme Ltd",
                "B12345678",
                "contact@acme.com");
        }
        [Fact]
        public void Execute_WithValidRequest_CreatesInvoice()
        {
            // Arrange
            var client = CreateClient();

            var line = new CreateInvoiceLineRequest("Backend development", 10m, 50m);

            var request = new CreateInvoiceRequest(client,
                new[]  { line });
           
            var service = new CreateInvoiceService();
            // Assert

            var invoice = service.Execute(request);


            Assert.Same(client, invoice.Client);
            Assert.Equal(InvoiceStatus.Draft, invoice.Status);
            Assert.Single(invoice.Lines);
        }

        [Fact]
        public void Execute_WithMultipleLines_CreatesInvoiceWithAllLines()
        {
            var client = CreateClient();

            var line1 = new CreateInvoiceLineRequest("Backend development", 10m, 50m);

            var line2 = new CreateInvoiceLineRequest("Frontend development", 8m, 40m);

            var request = new CreateInvoiceRequest(client,
                new[] { line1,line2 });

            var service = new CreateInvoiceService();

            var invoice = service.Execute(request);

            Assert.Equal(2, invoice.Lines.Count);
            Assert.Equal(820m, invoice.Subtotal);
        }

        [Fact]
        public void Execute_WithNoLines_CreatesEmptyDraftInvoice()
        {
            var client = CreateClient();

            var request = new CreateInvoiceRequest(client,
                Array.Empty<CreateInvoiceLineRequest>());

            var service = new CreateInvoiceService();

            var invoice = service.Execute(request);

            Assert.Same(client, invoice.Client);
            Assert.Empty(invoice.Lines);
            Assert.Equal(0m, invoice.Subtotal);
            Assert.Equal(InvoiceStatus.Draft, invoice.Status);
        }

        [Fact]
        public void Execute_WithNullLines_ThrowsArgumentException()
        {
            var client = CreateClient();

            var request = new CreateInvoiceRequest(
                client,
                null!);

            var service = new CreateInvoiceService();

            Assert.Throws<ArgumentNullException>(() =>
                service.Execute(request));
        }

        [Fact]
        public void Execute_WithNullRequest_ThrowsArgumentNullException()
        {
            var service = new CreateInvoiceService();

            Assert.Throws<ArgumentNullException>(() =>
                service.Execute(null!));
        }

        [Fact]
        public void Execute_WithInvalidLine_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var client = CreateClient();

            var line = new CreateInvoiceLineRequest(
                "Backend development",
                -1m,
                50m);

            var request = new CreateInvoiceRequest(
                client,
                new[] { line });

            var service = new CreateInvoiceService();

            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                service.Execute(request));
        }
    }
}
