namespace JourneyMiles.API.Shared.Communication.Requests;

public sealed class RouteRequest
{
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
}
