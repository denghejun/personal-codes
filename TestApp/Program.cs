using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using Autofac.Configuration.Core;
using DependencyService;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // this below code depedent on .NET Stander framework 1.0.0,so ...
            //var config = new ConfigurationBuilder();
            //config.AddJsonFile("autofac.json");
            // Register the ConfigurationModule with Autofac.
            //var module = new ConfigurationModule(config.Build());
            //var builder = new ContainerBuilder();
            //builder.RegisterModule(module);
            var builder = new ContainerBuilder();
            var container = builder.Build();

            var builder1 = new ContainerBuilder();
            builder1.Register((c, t) => container).As<IContainer>().SingleInstance();
            builder1.RegisterModule(new ConfigurationSettingsReader());
            builder1.Update(container);

            using (var scope = container.BeginLifetimeScope())
            {
                //var containerA = scope.Resolve<IContainer>();
                var appService = scope.Resolve<IApp>();
                Console.WriteLine(appService.Run());

                var fooService = scope.Resolve<IFoo>();
                Console.WriteLine(fooService.Calculate(3, 4));

                var barService = scope.Resolve<IBar>();
                Console.WriteLine(barService.Calculate("A", "B"));
            }

            Console.Read();
        }

        static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {

        }
    }
}
