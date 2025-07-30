using FluentMigrator.Runner;
using JourneyMiles.API.Domain.Repositories;
using JourneyMiles.API.Infrastructure.Repositories;
using JourneyMiles.API.Infrastructure.Services;
using System.Reflection;

namespace JourneyMiles.API.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITravelOfferRepository, TravelOfferRepository>();
        services.AddScoped<IRouteRepository, RouteRepository>();

        services.AddDbContext<AppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection")!;
        services.AddFluentMigratorCore().ConfigureRunner(options =>
        {
            options
            .AddSqlServer()
            .WithGlobalConnectionString(connectionString)
            .ScanIn(Assembly.Load("JourneyMiles.API")).For.All();
        });


        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("RedisConnection");
        });
        services.AddScoped<ICacheService, CacheService>();
    }
}
