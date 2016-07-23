using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.ExternalDriver.PrintDriver;
using AbstractFactory.InternalDriver.Abstract;

namespace AbstractFactory.InternalDriver.Instance
{
    public class AdaptedLowPrintDriver : PrintDriver
    {
        private LowPrintDriver _externalLowPrintDriver = new LowPrintDriver();
        public override void Print()
        {
            if (this._externalLowPrintDriver != null)
            {
                this._externalLowPrintDriver.PrintWithLowPerformance();
            }
        }
    }
}
