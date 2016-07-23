using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.DriverFactory.Instance
{
    public class LowDriverFactory : DriverFactory.Abstract.DriverFactory
    {
        private static LowDriverFactory instance;

        private LowDriverFactory()
        {
        }

        public static LowDriverFactory Instance { get { return instance ?? (instance = new LowDriverFactory()); } }

        public override InternalDriver.Abstract.DisplayDriver GetDisplayDriver()
        {
            return new InternalDriver.Instance.AdaptedLowDisplayDriver();
        }

        public override InternalDriver.Abstract.PrintDriver GetPrintDriver()
        {
            return new InternalDriver.Instance.AdaptedLowPrintDriver();
        }
    }
}
