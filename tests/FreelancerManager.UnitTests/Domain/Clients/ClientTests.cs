
using FreelancerManager.Domain.Clients;

namespace FreelancerManager.UnitTests.Domain.Clients
{
    public class ClientTests
    {
        [Fact]
        public void Constructor_WithValidValues_CreatesClient()
        {
            var client = new Client(
                "Acme Ltd",
                "B12345678",
                "contact@acme.com");

            Assert.Equal("Acme Ltd", client.Name);
            Assert.Equal("B12345678", client.TaxId);
            Assert.Equal("contact@acme.com", client.Email);
        }

        [Fact]
        public void Constructor_WithEmptyName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Client("", "B12345678", "contact@acme.com"));
        }
        [Fact]
        public void Constructor_WithEmptyTaxId_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Client("Acme Ltd", "", "contact@acme.com"));
        }

        [Fact]
        public void Constructor_WithWhitespaceEmail_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Client(
                    "Acme Ltd",
                    "B12345678",
                    "   "));
        }

        [Fact]
        public void Constructor_WithNullEmail_CreatesClient()
        {
            var client = new Client(
                "Acme Ltd",
                "B12345678",
                null);

            Assert.Null(client.Email);
        }
    }
}
