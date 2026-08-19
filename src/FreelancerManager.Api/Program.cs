using FreelancerManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


// Creates and configures the application builder
var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found.");


// Configures FreelancerManagerDbContext to use SQL Server
builder.Services.AddDbContext<FreelancerManagerDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();
app.Run();

