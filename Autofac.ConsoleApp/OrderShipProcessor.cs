using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.ConsoleApp.Services;

namespace Autofac.ConsoleApp
{
    internal class OrderShipProcessor
    {
        private IEmailSender _emailSender = null;
        public OrderShipProcessor(IEmailSender emailSender)
        {
            this._emailSender = emailSender;
        }

        public void Ship()
        {
            // do ship.
            this._emailSender.Send();
        }
    }
}
