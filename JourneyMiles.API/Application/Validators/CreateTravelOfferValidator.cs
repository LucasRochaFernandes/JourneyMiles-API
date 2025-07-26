using FluentValidation;
using JourneyMiles.API.Shared.Communication.Requests;

namespace JourneyMiles.API.Application.Validators;

public class CreateTravelOfferValidator : AbstractValidator<CreateTravelOfferRequest>
{
    public CreateTravelOfferValidator()
    {
        RuleFor(travelOffer => travelOffer.Price).GreaterThan(0).WithMessage("The price must be greater than 0");
        RuleFor(travelOffer => travelOffer.RouteId).NotNull().WithMessage("The route id must not be null");
        RuleFor(travelOffer => travelOffer.Period).NotNull().WithMessage("The period must not be null");
        RuleFor(travelOffer => travelOffer.Period.InitialDate)
            .NotEmpty().WithMessage("The start date must not be empty")
            .LessThanOrEqualTo(travelOffer => travelOffer.Period.EndDate)
            .WithMessage("The start date must be less than or equal to the end date");
    }
}
