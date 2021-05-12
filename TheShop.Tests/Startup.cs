using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Logger;
using TheShop.Domain.IoC;

namespace TheShop.Tests
{
    class Startup
    {
        public static IContainer GetContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterShopDependecies();

            builder.RegisterType<Logger>().As<ILogger>();

            return builder.Build();
        }
    }
}
