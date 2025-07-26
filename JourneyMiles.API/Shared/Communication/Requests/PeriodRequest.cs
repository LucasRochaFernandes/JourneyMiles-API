namespace JourneyMiles.API.Shared.Communication.Requests;

public sealed class PeriodRequest
{
    public DateTime InitialDate { get; set; }
    public DateTime EndDate { get; set; }
}
