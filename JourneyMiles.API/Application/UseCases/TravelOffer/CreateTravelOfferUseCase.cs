using AutoMapper;
using FluentValidation.Results;
using JourneyMiles.API.Application.Validators;
using JourneyMiles.API.Domain.Repositories;
using JourneyMiles.API.Shared.Communication.Requests;
using JourneyMiles.API.Shared.Exceptions;

namespace JourneyMiles.API.Application.UseCases.TravelOffer;

public class CreateTravelOfferUseCase : ICreateTravelOfferUseCase
{
    private readonly ITravelOfferRepository _travelOfferRepository;
    private readonly IRouteRepository _routeRepository;
    private readonly IMapper _mapper;

    public CreateTravelOfferUseCase(ITravelOfferRepository travelOfferRepository, IMapper mapper, IRouteRepository routeRepository)
    {
        _travelOfferRepository = travelOfferRepository;
        _mapper = mapper;
        _routeRepository = routeRepository;
    }

    public async Task<Guid> Execute(CreateTravelOfferRequest request)
    {
        await Validate(request);
        var travelOffer = _mapper.Map<Domain.Entities.TravelOffer>(request);
        var result = await _travelOfferRepository.Create(travelOffer);
        await _travelOfferRepository.Commit();
        return result;
    }
    private async Task Validate(CreateTravelOfferRequest request)
    {
        var validator = new CreateTravelOfferValidator();
        var result = validator.Validate(request);
        var isRouteExists = await _routeRepository.FindBy(route => route.Id.Equals(request.RouteId));
        if (isRouteExists is null)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, "Route Not Found"));
        }
        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(er => er.ErrorMessage).ToList();
            throw new ValidationException(errorMessages);
        }
    }
}
