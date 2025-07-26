using JourneyMiles.API.Domain.Entities;
using System.Linq.Expressions;

namespace JourneyMiles.API.Domain.Repositories;

public interface ITravelOfferRepository
{
    public Task<Guid> Create(TravelOffer entityTravelOffer);
    public Task<TravelOffer?> FindBy(Expression<Func<TravelOffer, bool>> condition, bool AsNoTracking = false);
    public void Update(TravelOffer entityUser);
    public Task Commit();
}
