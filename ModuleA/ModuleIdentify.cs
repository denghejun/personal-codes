using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DependencyService;
using ModuleA.Services;

namespace ModuleA
{
    public class ModuleIdentify : Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<Foo>().As<IFoo>();
        }
    }
}
