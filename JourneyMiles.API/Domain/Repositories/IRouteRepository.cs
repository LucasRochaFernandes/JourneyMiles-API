using JourneyMiles.API.Domain.Entities;
using System.Linq.Expressions;

namespace JourneyMiles.API.Domain.Repositories;

public interface IRouteRepository
{
    public Task<Guid> Create(Entities.Route entityRoute);
    public Task<Entities.Route?> FindBy(Expression<Func<Entities.Route, bool>> condition, bool AsNoTracking = false);
    public void Update(Entities.Route entityRoute);
    public Task Commit();
}
