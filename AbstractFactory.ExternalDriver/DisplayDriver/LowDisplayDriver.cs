using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.ExternalDriver.DisplayDriver
{
    public class LowDisplayDriver
    {
        public void DisplayWithLowPerformance()
        {
            Console.WriteLine("Low display.");
        }
    }
}
