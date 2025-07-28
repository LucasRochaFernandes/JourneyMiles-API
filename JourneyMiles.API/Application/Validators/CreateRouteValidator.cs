using FluentValidation;
using JourneyMiles.API.Shared.Communication.Requests;

namespace JourneyMiles.API.Application.Validators;

public class CreateRouteValidator : AbstractValidator<RouteRequest>
{
    public CreateRouteValidator()
    {
        RuleFor(route => route.Origin).NotEmpty().WithMessage("Origin must not be empty");
        RuleFor(route => route.Destination).NotEmpty().WithMessage("Destination must not be empty");
    }
}
