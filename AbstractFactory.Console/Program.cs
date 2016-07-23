using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.DriverFactory.Instance;

namespace AbstractFactory.Console
{
    class Program
    {



        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int size);

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumPrinters(int Flags,
  string Name,
  int Level,
  ref object pPrinterEnum,
  int cbBuf,
  ref object pcbNeeded,
  ref object pcReturned
);


        private static void Main(string[] args)
        {
            StringBuilder dp = new StringBuilder(256);
            int size = dp.Capacity;
            var r = GetDefaultPrinter(dp, ref size);
            object p1 = null, p2 = null, p3 = null;
            var d = EnumPrinters(1, "", 1, ref p1, 1234, ref p2, ref p3);

            FactoryManager.Current.GetDisplayDriver().Display();
            FactoryManager.Current.GetPrintDriver().Print();
            System.Console.Read();
        }
    }
}
