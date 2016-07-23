using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.ExternalDriver.PrintDriver;
using AbstractFactory.InternalDriver.Abstract;

namespace AbstractFactory.InternalDriver.Instance
{
    public class AdaptedHighPrintDriver : PrintDriver
    {
        private HighPrintDriver _externalHighPrintDriver = new HighPrintDriver();
        public override void Print()
        {
            if (this._externalHighPrintDriver != null)
            {
                this._externalHighPrintDriver.PrintWithHighPerformance();
            }
        }
    }
}
