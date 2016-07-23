using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDependentServices
{
    public interface ICalculate
    {
        int Add(int a, int b);
        int Sub(int a, int b);
    }
}
