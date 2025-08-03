using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Entities;
using Skinet.Infrastructure.Configurations;

namespace Skinet.Infrastructure.Persistence;

public class StoreContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductSetting).Assembly);
    }
}
