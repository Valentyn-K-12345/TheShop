using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Logger;

namespace TheShop
{
    class Startup
    {
        public static IContainer GetContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //Core

            builder.RegisterType<Logger.Logger>().As<ILogger>().SingleInstance();

            return builder.Build();
        }
    }
}
