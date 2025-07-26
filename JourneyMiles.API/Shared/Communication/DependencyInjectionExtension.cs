using AutoMapper;
using JourneyMiles.API.Shared.Communication.Services;

namespace JourneyMiles.API.Shared.Communication;

public static class DependencyInjectionExtension
{
    public static void AddCommunication(this IServiceCollection services)
    {
        var autoMapper = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new AutoMapping());
        }).CreateMapper();

        services.AddScoped(opt => autoMapper);
    }
}