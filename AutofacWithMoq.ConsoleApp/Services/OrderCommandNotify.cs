using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacWithMoq.ConsoleApp.Services
{
    public class OrderCommandNotify : INotification
    {
        public string Notify(string message)
        {
            Console.WriteLine(message);
            return message + " has been processed.";
        }
    }
}
