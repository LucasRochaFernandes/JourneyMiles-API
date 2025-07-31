using AutoMapper;
using JourneyMiles.API.Application.Validators;
using JourneyMiles.API.Domain.Repositories;
using JourneyMiles.API.Infrastructure.Services;
using JourneyMiles.API.Shared.Communication.Requests;
using JourneyMiles.API.Shared.Exceptions;

namespace JourneyMiles.API.Application.UseCases.Route;

public class CreateRouteUseCase : ICreateRouteUseCase
{
    private const string cacheKey = "routes";
    private readonly IRouteRepository _routeRepository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public CreateRouteUseCase(IRouteRepository routeRepository, IMapper mapper, ICacheService cacheService)
    {
        _routeRepository = routeRepository;
        _mapper = mapper;
        _cacheService = cacheService;
    }
    public async Task<Guid> Execute(RouteRequest request)
    {
        Validate(request);
        var route = _mapper.Map<Domain.Entities.Route>(request);
        var result = await _routeRepository.Create(route);
        await _routeRepository.Commit();
        await _cacheService.InvalidateCacheAsync(cacheKey);
        return result;
    }
    private void Validate(RouteRequest request)
    {
        var validator = new CreateRouteValidator();
        var result = validator.Validate(request);
        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(er => er.ErrorMessage).ToList();
            throw new ValidationException(errorMessages);
        }
    }
}
