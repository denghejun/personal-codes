using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DependencyService;

namespace TestApp
{
    public class ModuleIdentify : Autofac.Module
    {
        public static IContainer Contanier;
        public ModuleIdentify(IContainer containner)
        {
            Contanier = containner;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<App>().As<IApp>();
        }
    }
}
