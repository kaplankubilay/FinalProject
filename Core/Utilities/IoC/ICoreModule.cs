using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    /// <summary>
    /// Tüm projelerde kullanılabilecek
    /// </summary>
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
