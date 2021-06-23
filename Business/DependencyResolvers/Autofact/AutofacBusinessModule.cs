using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofact
{
    public class AutofacBusinessModule : Module
    {
        /// <summary>
        /// Manager içinde veri tutulmuyorsa singleton yapılabilir aksi halde örn tüm sepetler aynı olur. Data db de tutuluyorsa yine singleton yapılabilir.
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
