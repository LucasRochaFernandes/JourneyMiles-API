using JourneyMiles.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JourneyMiles.API.Infrastructure.Repositories;

public class RouteRepository : IRouteRepository
{
    private readonly AppDbContext _appDbContext;
    public RouteRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task Commit()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Guid> Create(Domain.Entities.Route entityRoute)
    {
        var result = await _appDbContext.Routes.AddAsync(entityRoute);
        return result.Entity.Id;
    }

    public async Task<Domain.Entities.Route?> FindBy(Expression<Func<Domain.Entities.Route, bool>> condition, bool AsNoTracking = false)
    {
        if (AsNoTracking)
        {
            return await _appDbContext.Routes.AsNoTracking().FirstOrDefaultAsync(condition);
        }
        else
        {
            return await _appDbContext.Routes.FirstOrDefaultAsync(condition);
        }
    }

    public void Update(Domain.Entities.Route entityRoute)
    {
        _appDbContext.Routes.Update(entityRoute);
    }
}
