using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyService;

namespace ModuleB
{
    public class Bar : IBar
    {
        public string Calculate(string a, string b)
        {
            return string.Concat(a, b);
        }
    }
}
