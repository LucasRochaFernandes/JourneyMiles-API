using JourneyMiles.API.Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;
public class RouteRepositoryBuilder
{
    private readonly Mock<IRouteRepository> _routeRepositoryMock;

    public RouteRepositoryBuilder()
    {
        _routeRepositoryMock = new Mock<IRouteRepository>();
    }
    public IRouteRepository Build()
    {
        return _routeRepositoryMock.Object;
    }
}
