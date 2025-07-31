namespace JourneyMiles.API.Infrastructure.Services;

public interface ICacheService
{
    Task<T> GetCachedDataAsync<T>(string key);
    Task SetCachedDataAsync<T>(string key, T data, TimeSpan expiration);
    Task InvalidateCacheAsync(string key);
}
