using JourneyMiles.API.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyMiles.API.Domain.Entities;

[Table("TravelOffers")]
public class TravelOffer
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public Period Period { get; set; }
    public double Price { get; set; }
    public Guid RouteId { get; set; }
    public virtual Route Route { get; set; }
}


