using Autofac;
using Autofac.Core;
using Autofac.Core.Lifetime;
using Autofac.Core.Resolving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyService
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //Register types here;

            return builder.Build();
        }
    }
}
