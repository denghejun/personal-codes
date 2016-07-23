using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.ConsoleApp.Services
{
    internal interface IOrderShipEmailSender : IEmailSender
    { }

    internal class OrderShipEmailSender : IOrderShipEmailSender
    {
        public void Send()
        {
            Console.WriteLine("Order has been shipped.");
        }
    }
}
