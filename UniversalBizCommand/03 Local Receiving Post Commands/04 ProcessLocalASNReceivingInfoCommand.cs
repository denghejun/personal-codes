using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class ProcessLocalASNReceivingInfoCommand : Command<ASNReceivingInfoEntity>
    {
        protected override bool CanExecute(ASNReceivingInfoEntity request)
        {
            return base.CanExecute(request);
        }

        protected override void Execute(ASNReceivingInfoEntity request)
        {
            // TO DO 01: Insert ASN Receive Detail 
            // TO DO 02: Update ASN Transaction
            // TO DO 03: Update ASN Master
            // 
        }
    }
}
