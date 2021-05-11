using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Interfaces;
using TheShop.Application.Services;
using TheShop.Application.Suppliers;
using TheShop.Data.Repository;
using TheShop.Domain.Interfaces;
using TheShop.Supplier.Domain.Interfaces;

namespace TheShop.Domain.IoC
{
    public static class DependencyContainer
    {
        public static ContainerBuilder RegisterShopDependecies(this ContainerBuilder builder)
        {

            //Repository

            builder.RegisterType<InMemoryArticleRepository>().As<IArticleRepository>().SingleInstance();


            //Service
            builder.RegisterType<ArticleService>().As<IArticleService>();

            //Suppliers

            builder.RegisterType<Supplier1>().As<ISupplier>();
            builder.RegisterType<Supplier2>().As<ISupplier>();
            builder.RegisterType<Supplier3>().As<ISupplier>();

            return builder;
        }
    }
}
