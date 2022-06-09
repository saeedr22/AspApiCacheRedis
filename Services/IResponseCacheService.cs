using System;

namespace AspApiCacheRedis.Services
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cachekey, object response, TimeSpan timeToLive);
        Task<string> GetCacheResponseAsync(string cacheKey);
    }
}