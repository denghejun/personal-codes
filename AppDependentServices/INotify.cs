using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDependentServices
{
    public interface INotify
    {
        bool Notify(string msg);
    }
}
