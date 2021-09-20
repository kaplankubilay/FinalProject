using System;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public interface ICacheRedisService
    {
        ValueTask CacheString(string key, string value, TimeSpan? expiration = null);

        ValueTask CacheModel<T>(string key, T model, TimeSpan? expiration = null);

        ValueTask<string?> ReadCachedString(string key);

        ValueTask<T?> ReadCachedModel<T>(string key);

        ValueTask DeleteCacheModel(string? key);
    }
}
