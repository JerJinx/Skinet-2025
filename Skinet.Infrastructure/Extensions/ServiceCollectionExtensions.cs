using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skinet.Domain.Interfaces;
using Skinet.Infrastructure.Persistence;
using Skinet.Infrastructure.Repositories;
using Skinet.Infrastructure.Seeders;

namespace Skinet.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<StoreContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });

        services.AddScoped<ISkinetSeeder, SkinetSeeder>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}
