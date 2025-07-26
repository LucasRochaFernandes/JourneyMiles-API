using FluentMigrator.Runner;
using JourneyMiles.API.Domain.Repositories;
using JourneyMiles.API.Infrastructure.Repositories;
using System.Reflection;

namespace JourneyMiles.API.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITravelOfferRepository, TravelOfferRepository>();

        services.AddDbContext<AppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection")!;
        services.AddFluentMigratorCore().ConfigureRunner(options =>
        {
            options
            .AddSqlServer()
            .WithGlobalConnectionString(connectionString)
            .ScanIn(Assembly.Load("JourneyMiles.API")).For.All();
        });
    }
}
