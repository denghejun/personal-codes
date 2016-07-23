using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.ConsoleApp.Services
{
    internal interface IOrderReceiptEmailSender : IEmailSender
    { }

    internal class OrderReceiptEmailSender : IOrderReceiptEmailSender
    {
        public void Send()
        {
            Console.WriteLine("Order has been received.");
        }
    }
}
