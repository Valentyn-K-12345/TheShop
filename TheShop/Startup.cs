using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Data.Repository;
using TheShop.Domain.Interfaces;

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
            builder.RegisterType<TheShop.ShopService>();

            return builder.Build();
        }
    }
}
