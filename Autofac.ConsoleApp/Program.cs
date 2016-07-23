using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.ConsoleApp.Services;
using Autofac.Features.Metadata;

namespace Autofac.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Sln_1();
            Sln_2();
            Sln_3();
            Sln_4();
            Sln_5();
            Console.Read();
        }

        static void Sln_1()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OrderReceiptEmailSender>().As<IEmailSender>().Keyed<IEmailSender>("Receipt");
            builder.RegisterType<OrderShipEmailSender>().As<IEmailSender>().Keyed<IEmailSender>("Ship");
            builder.RegisterType<OrderReceiptProcessor>().WithParameter(new Core.ResolvedParameter((p, c) => p.ParameterType == typeof(IEmailSender), (p, c) => c.ResolveKeyed<IEmailSender>("Receipt")));
            builder.RegisterType<OrderShipProcessor>().WithParameter(new Core.ResolvedParameter((p, c) => p.ParameterType == typeof(IEmailSender), (p, c) => c.ResolveKeyed<IEmailSender>("Ship")));
            var container = builder.Build();
            using (var lifetime = container.BeginLifetimeScope())
            {
                var orderReceiptProcessor = lifetime.Resolve<OrderReceiptProcessor>();
                var orderShipProceesor = lifetime.Resolve<OrderShipProcessor>();
                orderReceiptProcessor.Receive();
                orderShipProceesor.Ship();
            }
        }

        static void Sln_2()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new OrderReceiptProcessor(new OrderReceiptEmailSender()));
            builder.Register(c => new OrderShipProcessor(new OrderShipEmailSender()));
            var container = builder.Build();
            using (var lifetime = container.BeginLifetimeScope())
            {
                var orderReceiptProcessor = lifetime.Resolve<OrderReceiptProcessor>();
                var orderShipProceesor = lifetime.Resolve<OrderShipProcessor>();
                orderReceiptProcessor.Receive();
                orderShipProceesor.Ship();
            }
        }

        static void Sln_3()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OrderReceiptEmailSender>().As<IEmailSender>().AsSelf();
            builder.RegisterType<OrderShipEmailSender>().As<IEmailSender>().AsSelf();
            builder.Register(c => new OrderReceiptProcessor(c.Resolve<OrderReceiptEmailSender>()));
            builder.Register(c => new OrderShipProcessor(c.Resolve<OrderShipEmailSender>()));
            var container = builder.Build();
            using (var lifetime = container.BeginLifetimeScope())
            {
                var orderReceiptProcessor = lifetime.Resolve<OrderReceiptProcessor>();
                var orderShipProceesor = lifetime.Resolve<OrderShipProcessor>();
                orderReceiptProcessor.Receive();
                orderShipProceesor.Ship();
            }
        }

        static void Sln_4()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OrderReceiptEmailSender>().As<IEmailSender>().WithMetadata("usage", "receipt");
            builder.RegisterType<OrderShipEmailSender>().As<IEmailSender>().WithMetadata("usage", "ship");
            builder.RegisterType<OrderReceiptProcessor>().WithParameter(new Core.ResolvedParameter((p, c) => p.ParameterType == typeof(IEmailSender), (p, c) => c.Resolve<IEnumerable<Meta<IEmailSender>>>().First(o => o.Metadata["usage"] == "receipt").Value));
            builder.RegisterType<OrderShipProcessor>().WithParameter(new Core.ResolvedParameter((p, c) => p.ParameterType == typeof(IEmailSender), (p, c) => c.Resolve<IEnumerable<Meta<IEmailSender>>>().First(o => o.Metadata["usage"] == "ship").Value));
            var container = builder.Build();
            using (var lifetime = container.BeginLifetimeScope())
            {
                var orderReceiptProcessor = lifetime.Resolve<OrderReceiptProcessor>();
                var orderShipProceesor = lifetime.Resolve<OrderShipProcessor>();
                orderReceiptProcessor.Receive();
                orderShipProceesor.Ship();
            }
        }

        static void Sln_5()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OrderReceiptEmailSender>().As<IOrderReceiptEmailSender>();
            builder.RegisterType<OrderShipEmailSender>().As<IOrderShipEmailSender>();
            builder.RegisterType<OrderReceiptProcessor>();
            builder.RegisterType<OrderShipProcessor>();
            var container = builder.Build();
            using (var lifetime = container.BeginLifetimeScope())
            {
                //var orderReceiptProcessor = lifetime.Resolve<OrderReceiptProcessor>();
                //var orderShipProceesor = lifetime.Resolve<OrderShipProcessor>();
                //orderReceiptProcessor.Receive();
                //orderShipProceesor.Ship();
            }
        }
    }
}
