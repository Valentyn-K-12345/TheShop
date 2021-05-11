using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Data.Repository;
using TheShop.Domain.Interfaces;
using TheShop.Application.Services;
using TheShop.Supplier.Domain.Interfaces;

namespace TheShop
{
    class Startup
    {
        public static IContainer GetContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //Repository

            builder.RegisterType<InMemoryArticleRepository>().As<IArticleRepository>().SingleInstance();


            //Service
            builder.RegisterType<ArticleService>();

            //Suppliers

            builder.RegisterType<TheShop.Application.Suppliers.Supplier1>().As<ISupplier>();
            builder.RegisterType<TheShop.Application.Suppliers.Supplier2>().As<ISupplier>();
            builder.RegisterType<TheShop.Application.Suppliers.Supplier3>().As<ISupplier>();

            return builder.Build();
        }
    }
}
