using System;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace AspApiCacheRedis.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;
        public ResponseCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task CacheResponseAsync(string cachekey, object response, TimeSpan timeToLive)
        {
            if (response == null) return;
            var serializedResponse = JsonConvert.SerializeObject(response);
            await _distributedCache.SetStringAsync(cachekey, serializedResponse, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = timeToLive });
        }

        public async Task<string> GetCacheResponseAsync(string cacheKey)
        {
            var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);
            return string.IsNullOrEmpty(cachedResponse) ? "" : cachedResponse;
        }
    }
}