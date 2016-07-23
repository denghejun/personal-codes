using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class ProcessLocalReceivingBatchNumberCommand : Command<ProcessLocalReceivingBatchNumberCommandRequest>
    {
        protected override void Execute(ProcessLocalReceivingBatchNumberCommandRequest request)
        {
            // TO DO 01: Update CurrentSN Transfered
            // TO DO 02: SerialNumber.dbo.TrackingForInbound BatchNumber
            // TO DO 03: SerialNumber.dbo.WMS_VendorViolationCase_V2  BatchNumber
        }
    }
}
