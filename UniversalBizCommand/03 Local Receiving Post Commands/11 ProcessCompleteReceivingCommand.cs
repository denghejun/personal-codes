using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class ProcessCompleteReceivingCommand : Command<ProcessCompleteReceivingCommandRequest>
    {
        protected override void Execute(ProcessCompleteReceivingCommandRequest request)
        {
            /************* TO Do LIST *****************
             * 01. Close Task
             * 02. Create Put Away Task
             * 
             * 03. Send WRD Message & Move Out WRD SN
             * **/
        }
    }
}
