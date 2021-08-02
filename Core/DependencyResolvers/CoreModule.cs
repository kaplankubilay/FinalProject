using System;
using System.Collections.Generic;
using System.Text;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    /// <summary>
    /// genel servis bağımlılıklarını burada geçeceğiz.
    /// </summary>
    public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            //IMemoryCache nin injection u için kullanılır.Hazır instance oluşturur.
            services.AddMemoryCache();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddSingleton<ICacheManager, MemoryCacheManager>();

        }
    }
}
