using FreelancerManager.Domain.Invoices;

namespace FreelancerManager.UnitTests.Domain.Invoices;

public class InvoiceLineTests
{
    [Fact]
    public void Constructor_WithValidValues_CreatesInvoiceLine()
    {
        // Arrange
        var description = "Backend development";
        var quantity = 10m;
        var unitPrice = 50m;

        // Act
        var invoiceLine = new InvoiceLine(description, quantity, unitPrice);

        // Assert
        Assert.Equal(description, invoiceLine.Description);
        Assert.Equal(quantity, invoiceLine.Quantity);
        Assert.Equal(unitPrice, invoiceLine.UnitPrice);
    }

    [Fact]
    public void Subtotal_WithValidValues_ReturnsQuantityTimesUnitPrice()
    {
        // Arrange
        var invoiceLine = new InvoiceLine(
            "Backend development",
            10m,
            50m);

        // Act
        var subtotal = invoiceLine.Subtotal;

        // Assert
        Assert.Equal(500m, subtotal);
    }

    [Fact]
    public void Constructor_WithEmptyDescription_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new InvoiceLine(string.Empty, 10m, 50m));
    }

    [Fact]
    public void Constructor_WithZeroQuantity_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new InvoiceLine("Backend development", 0m, 50m));
    }

    [Fact]
    public void Constructor_WithNegativeQuantity_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new InvoiceLine("Backend development", -1m, 50m));
    }

    [Fact]
    public void Constructor_WithNegativeUnitPrice_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new InvoiceLine("Backend development", 10m, -1m));
    }

    [Fact]
    public void Constructor_WithZeroUnitPrice_CreatesInvoiceLine()
    {
        // Act
        var invoiceLine = new InvoiceLine(
            "Free consultation",
            1m,
            0m);

        // Assert
        Assert.Equal(0m, invoiceLine.UnitPrice);
        Assert.Equal(0m, invoiceLine.Subtotal);
    }
    [Fact]
    public void Constructor_WithNullDescription_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new InvoiceLine(null!, 10m, 50m));
    }

    [Fact]
    public void Constructor_WithWhitespaceDescription_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new InvoiceLine("   ", 10m, 50m));
    }
}