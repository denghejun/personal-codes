using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEFConsoleExample.Interface;

namespace MEFConsoleExample.Core
{
    [Export(typeof(ILogger))]
    internal class ConsoleLogger : ILogger
    {
        public void WriteMessage(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}
