using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.ExternalDriver.DisplayDriver;
using AbstractFactory.InternalDriver.Abstract;

namespace AbstractFactory.InternalDriver.Instance
{
    public class AdaptedHighDisplayDriver : DisplayDriver
    {
        private HighDisplayDriver _externalHighDisplayDriver = new HighDisplayDriver();
        public override void Display()
        {
            if (this._externalHighDisplayDriver != null)
            {
                this._externalHighDisplayDriver.DisplayWithHighPerformance();
            }
        }
    }
}
