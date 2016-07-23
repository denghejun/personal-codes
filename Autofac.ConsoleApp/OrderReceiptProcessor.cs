using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.ConsoleApp.Services;

namespace Autofac.ConsoleApp
{
    internal class OrderReceiptProcessor
    {
        private IEmailSender _emailSender = null;
        public OrderReceiptProcessor(IEmailSender emailSender)
        {
            this._emailSender = emailSender;
        }

        public void Receive()
        {
            // do receiving
            this._emailSender.Send();
        }
    }
}
