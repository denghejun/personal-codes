using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class ProcessActiveScanedUPCMessageCommand : Command<ProcessActiveScanedUPCMessageCommandRequest>
    {
        protected override void Execute(ProcessActiveScanedUPCMessageCommandRequest request)
        {
            // Send scaned UPC to d2.
        }
    }
}
