using AutoMapper;
using JourneyMiles.API.Shared.Communication.Requests;

namespace JourneyMiles.API.Shared.Communication.Services;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
        DomainToResponse();
    }

    private void RequestToDomain()
    {
        CreateMap<RouteRequest, Domain.Entities.Route>();
        CreateMap<PeriodRequest, Domain.ValueObjects.Period>();
        CreateMap<CreateTravelOfferRequest, Domain.Entities.TravelOffer>();
    }
    private void DomainToResponse()
    {

    }
}
