using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Domain.IoC;

namespace TheShop.Tests
{
    class Startup
    {
        public static IContainer GetContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterShopDependecies();

            return builder.Build();
        }
    }
}
