using JourneyMiles.API.Application.UseCases.Route;
using JourneyMiles.API.Shared.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JourneyMiles.API.Controllers;
[Route("[controller]")]
[ApiController]
public class RouteController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] RouteRequest request,
        [FromServices] ICreateRouteUseCase createRouteUseCase)
    {
        var result = await createRouteUseCase.Execute(request);
        return Created(string.Empty, new { Id = result });
    }
}
