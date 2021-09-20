using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace RedisManages.Abstract
{
    public interface IApplicationRedisCache
    {
        Task<IList<Product>> GetProductsCache();
        Task<IList<Product>> GetProduction();

        Task DeleteCache(string? key);
    }
}
