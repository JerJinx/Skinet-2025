using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Entities;
using Skinet.Infrastructure.Persistence;

namespace Skinet.Infrastructure.Seeders;

internal class SkinetSeeder(StoreContext context) : ISkinetSeeder
{
    public async Task Seed()
    {
        if (context.Database.GetPendingMigrations().Any())
        {
            await context.Database.MigrateAsync();
        }

        if (await context.Database.CanConnectAsync())
        {
            if (!context.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("../Skinet.Infrastructure/Seeders/SeedData/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products == null) return;

                context.Products.AddRange(products);

                await context.SaveChangesAsync();
            }
        }            
    }
}
