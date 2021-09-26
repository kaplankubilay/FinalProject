using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQManages.Connection;
using RabbitMQManages.Publisher;

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

            //kronometre için instance oluşturur.
            services.AddSingleton<Stopwatch>();

            //RABBITMq CONFIGURATIONS
            //rabbitMq connection configuration
            services.AddSingleton<IConnectionProvider>(new ConnectionProvider("amqp://localhost"));
            //rabbitMq publisher configuration
            services.AddSingleton<IPublisher>(x => new Publisher(x.GetService<IConnectionProvider>(),
                "final_exchange",
                ExchangeType.Topic));
            //services.AddSingleton<ISubscriber>(x => new Subscriber(x.GetService<IConnectionProvider>(),
            //    "final_exchange",
            //    "report_queue",
            //    "report.*",
            //    ExchangeType.Topic));
        }
    }
}
