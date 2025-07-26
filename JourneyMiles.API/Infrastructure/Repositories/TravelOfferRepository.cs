
using JourneyMiles.API.Domain.Entities;
using JourneyMiles.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JourneyMiles.API.Infrastructure.Repositories;

public class TravelOfferRepository : ITravelOfferRepository
{
    private readonly AppDbContext _appDbContext;

    public TravelOfferRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Commit()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Guid> Create(TravelOffer entityTravelOffer)
    {
        var result = await _appDbContext.TravelOffers.AddAsync(entityTravelOffer);
        return result.Entity.Id;
    }

    public async Task<TravelOffer?> FindBy(Expression<Func<TravelOffer, bool>> condition, bool AsNoTracking = false)
    {
        if (AsNoTracking)
        {
            return await _appDbContext.TravelOffers.AsNoTracking().FirstOrDefaultAsync(condition);
        }
        else
        {
            return await _appDbContext.TravelOffers.FirstOrDefaultAsync(condition);
        }
    }

    public void Update(TravelOffer entityUser)
    {
        _appDbContext.TravelOffers.Update(entityUser);
    }
}
