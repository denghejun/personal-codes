using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class ProcessExternalPackageLabelCommand : Command<ExternalPackageLabelCommandRequest>
    {
        protected override void Execute(ExternalPackageLabelCommandRequest request)
        {
            // TO DO 01: Update ASN Package status if post by shipment(= if has external package.)
            // TO DO 02: Update ASN serialnumber status if post by shipment
        }
    }
}
