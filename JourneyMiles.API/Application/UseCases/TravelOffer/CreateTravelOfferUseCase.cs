using AutoMapper;
using JourneyMiles.API.Application.Validators;
using JourneyMiles.API.Domain.Repositories;
using JourneyMiles.API.Shared.Communication.Requests;
using JourneyMiles.API.Shared.Exceptions;

namespace JourneyMiles.API.Application.UseCases.TravelOffer;

public class CreateTravelOfferUseCase : ICreateTravelOfferUseCase
{
    private readonly ITravelOfferRepository _travelOfferRepository;
    private readonly IMapper _mapper;

    public CreateTravelOfferUseCase(ITravelOfferRepository travelOfferRepository, IMapper mapper)
    {
        _travelOfferRepository = travelOfferRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Execute(CreateTravelOfferRequest request)
    {
        Validate(request);
        var travelOffer = _mapper.Map<Domain.Entities.TravelOffer>(request);
        var result = await _travelOfferRepository.Create(travelOffer);
        await _travelOfferRepository.Commit();
        return result;
    }
    private void Validate(CreateTravelOfferRequest request)
    {
        var validator = new CreateTravelOfferValidator();
        var result = validator.Validate(request);
        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(er => er.ErrorMessage).ToList();
            throw new ValidationException(errorMessages);
        }
    }
}
