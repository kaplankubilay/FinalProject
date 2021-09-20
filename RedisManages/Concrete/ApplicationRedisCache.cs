using RedisManages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Caching.Redis;
using DataAccess.Abstract;
using Entities.Concrete;

namespace RedisManages.Concrete
{
    public class ApplicationRedisCache : IApplicationRedisCache
    {
        private readonly ICacheRedisService _cacheRedisService;
        private readonly IProductDal _productDal;

        public ApplicationRedisCache(ICacheRedisService cacheRedisService, IProductDal productDal)
        {
            _cacheRedisService = cacheRedisService;
            _productDal = productDal;
        }

        public async Task<IList<Product>> GetProductsCache()
        {
            const string key = "Products_2";
            IList<Product>? list = await _cacheRedisService.ReadCachedModel<IList<Product>>(key);
            if (list == null)
            {
                var result = _productDal.GetAll();
                list = result;
                await _cacheRedisService.CacheModel(key, list, TimeSpan.FromMinutes(2));
            }
            return list;

        }

        public async Task<IList<Product>> GetProduction()
        {
            const string key = "Production_5";
            IList<Product>? list = await _cacheRedisService.ReadCachedModel<IList<Product>>(key);
            if (list == null)
            {
                var result = _productDal.GetAll();
                list = result;
                await _cacheRedisService.CacheModel(key, list, TimeSpan.FromMinutes(5));
            }
            return list;

        }
    }
}
