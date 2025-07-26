using JourneyMiles.API.Shared.Communication.Requests;

namespace JourneyMiles.API.Application.UseCases.TravelOffer;

public interface ICreateTravelOfferUseCase
{
    public Task<Guid> Execute(CreateTravelOfferRequest request);
}
