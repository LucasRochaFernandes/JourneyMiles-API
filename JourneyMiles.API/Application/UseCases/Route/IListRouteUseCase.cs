namespace JourneyMiles.API.Application.UseCases.Route;

public interface IListRouteUseCase
{
    Task<IEnumerable<Domain.Entities.Route>?> Execute();
}
