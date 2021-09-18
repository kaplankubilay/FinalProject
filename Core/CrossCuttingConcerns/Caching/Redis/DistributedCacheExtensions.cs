using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, 
            string recordId, 
            T data,
            TimeSpan? absoluteExpireTime = null, 
            TimeSpan? unusedExpireTime = null)
        {
            var options= new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(5);
            options.SlidingExpiration = unusedExpireTime ?? TimeSpan.FromSeconds(60);

            //var jsonData = JsonSerializer.Serialize(data);
            var jsonData = JsonConvert.SerializeObject(data);
            await cache.SetStringAsync(recordId, jsonData, options);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);

            if (jsonData is null)
            {
                return default(T);
            }

            //return JsonSerializer.Deserializer<T>(jsonData);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}
