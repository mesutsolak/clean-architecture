namespace App.Caching;

public class CacheService(IMemoryCache memoryCache) : ICacheService
{
    public Task AddAsync<T>(string cacheKey, T value, TimeSpan expireTimeSpan)
    {
        var cacheOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expireTimeSpan,
        };

        memoryCache.Set(cacheKey, value, cacheOptions);

        return Task.CompletedTask;
    }

    public Task<T?> GetAsync<T>(string cacheKey)
    {
        return Task.FromResult(memoryCache.TryGetValue(cacheKey, out T cacheItem) ? cacheItem : default);
    }

    public Task RemoveAsync(string cacheKey)
    {
        memoryCache.Remove(cacheKey);

        return Task.CompletedTask;
    }
}