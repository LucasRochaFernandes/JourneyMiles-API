
using JourneyMiles.API.Domain.Repositories;
using JourneyMiles.API.Infrastructure.Services;

namespace JourneyMiles.API.Application.UseCases.Route;

public class ListRouteUseCase : IListRouteUseCase
{
    private const string cacheKey = "routes";
    private readonly IRouteRepository _routeRepository;
    private readonly ICacheService _cacheService;
    public ListRouteUseCase(IRouteRepository routeRepository, ICacheService cacheService)
    {
        _routeRepository = routeRepository;
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<Domain.Entities.Route>?> Execute()
    {
        var cacheResult = await _cacheService.GetCachedDataAsync<IEnumerable<Domain.Entities.Route>>(cacheKey);
        if (cacheResult is not null)
        {
            return cacheResult;
        }
        var result = await _routeRepository.List();
        await _cacheService.SetCachedDataAsync(cacheKey, result, TimeSpan.FromMinutes(5));
        return result;
    }
}
