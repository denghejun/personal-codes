using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacWithMoq.ConsoleApp.Services
{
    public interface INotification
    {
        string Notify(string message);
    }
}
