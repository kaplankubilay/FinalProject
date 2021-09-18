using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class CacheRedisService : ICacheRedisService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly TimeSpan _defaultAbsoluteExpirationRelativeToNow;

        public CacheRedisService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;

            _defaultAbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
        }

        public async ValueTask CacheModel<T>(string key, T model, TimeSpan? expiration = null)
        {
            string modelAsString = JsonSerializer.Serialize<T>(model);
            await CacheString(key, modelAsString, expiration);
        }

        public async ValueTask CacheString(string key, string value, TimeSpan? expiration = null)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = expiration ?? _defaultAbsoluteExpirationRelativeToNow,
            };

            await _distributedCache.SetStringAsync(key, value, options);
        }

        public async ValueTask<T?> ReadCachedModel<T>(string key)
        {
            string? value = await ReadCachedString(key);
            if (value is null)
                return default;

            return JsonSerializer.Deserialize<T?>(value);
        }

        public async ValueTask<string?> ReadCachedString(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }
    }
}
