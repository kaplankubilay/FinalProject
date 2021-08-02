using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Castle.DynamicProxy;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Performans
{
    /// <summary>
    /// Metodun çalışma süresinin tespiti için kullanılır.
    /// </summary>
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interval">Tanımlanacak sınır süre parametresi</param>
        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        /// <summary>
        /// Metodun önünde kronometre başlatıldı.
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        /// <summary>
        /// metod sonunda kronometrede gecen süre hesaplanılır.Burada console a log olarak atılmıştır farklı şekilde sonuc yönlendirilebilir.
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
