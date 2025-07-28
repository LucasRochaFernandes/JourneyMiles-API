using JourneyMiles.API.Application.UseCases.Route;
using JourneyMiles.API.Application.UseCases.TravelOffer;

namespace JourneyMiles.API.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateTravelOfferUseCase, CreateTravelOfferUseCase>();
        services.AddScoped<ICreateRouteUseCase, CreateRouteUseCase>();
    }
}
