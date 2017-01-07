using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEFConsoleExample.Interface;

namespace MEFConsoleExample.Core
{
    [Export(typeof(ILogger))]
    internal class DebugLogger : ILogger
    {

        public void WriteMessage(string msg)
        {
            Debug.WriteLine(msg);
        }


    }
}
