using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace TestApp
{
    public class AppBase
    {
        public AppBase()
        {
        }

        protected virtual void Loaded(IContainer container)
        { 
        
        }
    }
}
