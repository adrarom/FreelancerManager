using FreelancerManager.Domain.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FreelancerManager.Infrastructure.Persistence.Configurations
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired();
            builder.HasOne(x => x.Client)
                .WithMany()
                .HasForeignKey("ClientId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.OwnsMany(x => x.Lines, line =>
            {
                line.ToTable("InvoiceLines");

                line.WithOwner()
                    .HasForeignKey("InvoiceId");

                line.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(InvoiceLine.MaxDescriptionLength);

                line.Property(x => x.Quantity)
                    .IsRequired()
                    .HasPrecision(18, 4);

                line.Property(x => x.UnitPrice)
                    .IsRequired()
                    .HasPrecision(18, 2);
            });

        }
    }
}
