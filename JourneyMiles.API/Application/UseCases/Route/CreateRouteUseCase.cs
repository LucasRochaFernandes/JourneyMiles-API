using AutoMapper;
using JourneyMiles.API.Application.Validators;
using JourneyMiles.API.Domain.Repositories;
using JourneyMiles.API.Shared.Communication.Requests;
using JourneyMiles.API.Shared.Exceptions;

namespace JourneyMiles.API.Application.UseCases.Route;

public class CreateRouteUseCase : ICreateRouteUseCase
{
    private readonly IRouteRepository _routeRepository;
    private readonly IMapper _mapper;

    public CreateRouteUseCase(IRouteRepository routeRepository, IMapper mapper)
    {
        _routeRepository = routeRepository;
        _mapper = mapper;
    }
    public async Task<Guid> Execute(RouteRequest request)
    {
        Validate(request);
        var route = _mapper.Map<Domain.Entities.Route>(request);
        var result = await _routeRepository.Create(route);
        await _routeRepository.Commit();
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
