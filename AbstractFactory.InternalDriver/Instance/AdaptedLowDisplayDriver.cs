using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.ExternalDriver.DisplayDriver;
using AbstractFactory.InternalDriver.Abstract;

namespace AbstractFactory.InternalDriver.Instance
{
    public class AdaptedLowDisplayDriver : DisplayDriver
    {
        private LowDisplayDriver _externalLowDisplayDriver = new LowDisplayDriver();
        public override void Display()
        {
            if (this._externalLowDisplayDriver != null)
            {
                this._externalLowDisplayDriver.DisplayWithLowPerformance();
            }
        }
    }
}
