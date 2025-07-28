using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using JourneyMiles.API.Application.UseCases.Route;
using JourneyMiles.API.Domain.Repositories;
namespace JourneyMiles.UnitTests.UseCases;
public class CreateRouteUseCaseTest
{
    [Fact]
    public async void Success()
    {
        var routeRequest = RouteRequestBuilder.Build();
        var routeRepository = CreateRouteRepository();
        var autoMapper = AutoMapperBuilder.Build();
        var useCase = new CreateRouteUseCase(routeRepository, autoMapper);

        var result = await useCase.Execute(routeRequest);


    }


    private static IRouteRepository CreateRouteRepository()
    {
        var userRepositoryBuilder = new RouteRepositoryBuilder();
        return userRepositoryBuilder.Build();
    }
}
