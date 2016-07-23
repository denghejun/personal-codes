using System;
using Autofac;
using Autofac.Configuration;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader());
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var appCoreInstance = scope.Resolve<ConsoleApp.Core>();
                appCoreInstance.CalculateComplex(1,7);
            }

            Console.Read();
        }
    }
}
