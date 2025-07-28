using JourneyMiles.API.Shared.Communication.Requests;

namespace JourneyMiles.API.Application.UseCases.Route;

public interface ICreateRouteUseCase
{
    Task<Guid> Execute(RouteRequest request);
}
