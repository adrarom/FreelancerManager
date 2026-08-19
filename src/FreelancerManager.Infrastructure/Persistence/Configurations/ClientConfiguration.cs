using FreelancerManager.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelancerManager.Infrastructure.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(Client.MaxNameLength);
            builder.Property(x => x.TaxId).IsRequired().HasMaxLength(Client.MaxTaxIdLength);
            builder.Property(x => x.Email).IsRequired(false).HasMaxLength(Client.MaxEmailLength);
        }
    }
}
