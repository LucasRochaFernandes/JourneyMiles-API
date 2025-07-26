using JourneyMiles.API.Application.UseCases.TravelOffer;
using JourneyMiles.API.Shared.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JourneyMiles.API.Controllers;

[Route("[controller]")]
[ApiController]
public class TravelOfferController : ControllerBase
{
    [HttpPost("create-travel-offer")]
    public async Task<IActionResult> Create(
        [FromBody] CreateTravelOfferRequest request,
        [FromServices] ICreateTravelOfferUseCase createTravelOfferUseCase)
    {
        var result = await createTravelOfferUseCase.Execute(request);
        return Created(string.Empty, new { Id = result });
    }
}
