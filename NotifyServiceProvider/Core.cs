using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDependentServices;

namespace NotifyServiceProvider
{
    public class Core : INotify
    {
        public bool Notify(string msg)
        {
            Console.WriteLine(msg);
            return true;
        }
    }
}
