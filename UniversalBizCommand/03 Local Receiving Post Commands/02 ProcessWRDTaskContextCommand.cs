using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class ProcessWRDTaskContextCommand : Command<ProcessWRDTaskContextCommandRequest, ProcessWRDTaskContextCommandResponse>
    {
        protected override ProcessWRDTaskContextCommandResponse Execute(ProcessWRDTaskContextCommandRequest request)
        {
            try
            {
                // TO DO: Update WRD task context with input tracking number.
                return new ProcessWRDTaskContextCommandResponse() { IsSuccess = true };
            }
            catch (Exception e)
            {
                return new ProcessWRDTaskContextCommandResponse() { IsSuccess = false, Result = new ReceivingPostResultEntity() { OutMsg = e.Message } };
            }
        }
    }
}
