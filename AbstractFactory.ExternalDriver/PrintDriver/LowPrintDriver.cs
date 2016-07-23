using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.ExternalDriver.PrintDriver
{
    public class LowPrintDriver
    {
        public void PrintWithLowPerformance()
        {
            Console.WriteLine("Low print.");
        }
    }
}
