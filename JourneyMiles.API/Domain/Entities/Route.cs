using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyMiles.API.Domain.Entities;

[Table("Routes")]
public class Route
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Origin { get; set; }
    public string Destination { get; set; }
}
