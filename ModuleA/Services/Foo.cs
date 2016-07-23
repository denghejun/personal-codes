using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyService;

namespace ModuleA.Services
{
    public class Foo : IFoo
    {
        public int Calculate(int a, int b)
        {
            return a + b;
        }
    }
}
