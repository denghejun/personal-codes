using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDependentServices;
using Autofac;

namespace NotifyServiceProvider
{
    public class ModuleIdentify : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Core>().As<INotify>();
        }
    }
}
