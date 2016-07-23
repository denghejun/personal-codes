using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacWithMoq.ConsoleApp.Services;

namespace AutofacWithMoq.ConsoleApp
{
    public class OrderCommand
    {
        INotification _notifier = null;
        public OrderCommand(INotification notifier)
        {
            this._notifier = notifier;
        }

        public string Execute(string msg)
        {
            // DO STH
            return this._notifier.Notify(msg);
        }
    }
}
