using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.InternalDriver.Abstract;

namespace AbstractFactory.DriverFactory.Abstract
{
    public abstract class DriverFactory
    {
        public abstract DisplayDriver GetDisplayDriver();
        public abstract PrintDriver GetPrintDriver();
    }
}
