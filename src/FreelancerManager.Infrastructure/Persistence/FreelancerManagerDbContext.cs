using FreelancerManager.Domain.Clients;
using FreelancerManager.Domain.Invoices;
using FreelancerManager.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FreelancerManager.Infrastructure.Persistence;

public class FreelancerManagerDbContext : DbContext
{
    public FreelancerManagerDbContext(
        DbContextOptions<FreelancerManagerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
    }

    public DbSet<Client> Clients => Set<Client>();

    public DbSet<Invoice> Invoices => Set<Invoice>();
}