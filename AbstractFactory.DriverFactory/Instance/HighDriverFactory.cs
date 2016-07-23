using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.DriverFactory.Instance
{
    public class HighDriverFactory : DriverFactory.Abstract.DriverFactory
    {
        private static HighDriverFactory instance;

        private HighDriverFactory()
        {

        }

        public static HighDriverFactory Instance { get { return instance ?? (instance = new HighDriverFactory()); } }

        public override InternalDriver.Abstract.DisplayDriver GetDisplayDriver()
        {
            return new InternalDriver.Instance.AdaptedHighDisplayDriver();
        }

        public override InternalDriver.Abstract.PrintDriver GetPrintDriver()
        {
            return new InternalDriver.Instance.AdaptedHighPrintDriver();
        }
    }
}
