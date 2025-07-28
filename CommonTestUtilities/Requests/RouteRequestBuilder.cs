using Bogus;
using JourneyMiles.API.Shared.Communication.Requests;

namespace CommonTestUtilities.Requests;
public class RouteRequestBuilder
{
    public static RouteRequest Build()
    {
        return new Faker<RouteRequest>()
            .RuleFor(request => request.Origin, (f) => f.Address.FullAddress())
            .RuleFor(request => request.Destination, (f) => f.Address.FullAddress());
    }
}
