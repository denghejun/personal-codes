using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class ProcessInventoryBorrowCommand : Command<ProcessInventoryBorrowCommandRequest, ProcessInventoryBorrowCommandResponse>
    {
        protected override ProcessInventoryBorrowCommandResponse Execute(ProcessInventoryBorrowCommandRequest request)
        {
            // TO DO: Get current order's MatchList & NotDeliveriedList, if has. return failed.
            return new ProcessInventoryBorrowCommandResponse() { IsSuccess = true };
        }
    }
}
