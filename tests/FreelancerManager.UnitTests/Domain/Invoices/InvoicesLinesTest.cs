using FreelancerManager.Domain.Invoices;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace FreelancerManager.UnitTests.Domain.Invoices
{
    public class InvoicesLinesTest
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

            //Assert

            Assert.Equal(description, invoiceLine.Description);
            Assert.Equal(quantity, invoiceLine.Quantity);
            Assert.Equal(unitPrice, invoiceLine.UnitPrice);
        }

        [Fact]
        public void Subtotal_WithValidValues_ReturnQuantityTimesUnitPrice()
        {
            
            // Arrange

            var description = "Backend development";
            var quantity = 10m;
            var unitPrice = 50m;

            // Act

            var invoiceLine = new InvoiceLine(description, quantity, unitPrice);

            //Assert

            Assert.Equal(500m, invoiceLine.Subtotal);
        }
    }
}
