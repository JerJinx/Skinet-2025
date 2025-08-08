using Skinet.Infrastructure.Extensions;
using Skinet.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

try
{
    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<ISkinetSeeder>();
    await seeder.Seed();

}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

app.Run();
