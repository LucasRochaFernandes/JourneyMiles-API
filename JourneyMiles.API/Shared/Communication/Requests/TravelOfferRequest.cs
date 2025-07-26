namespace JourneyMiles.API.Shared.Communication.Requests;

public sealed class CreateTravelOfferRequest
{
    public Guid RouteId { get; set; }
    public PeriodRequest Period { get; set; }
    public double Price { get; set; } = 0.0;
}
