using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class ProcessGoodsReceiptNoticeMessageCommand : Command<ProcessGoodsReceiptNoticeCommandRequest>
    {
        protected override void Execute(ProcessGoodsReceiptNoticeCommandRequest request)
        {
            // TO DO: Get The Full New Goods Receive Notice Send To Q.
        }
    }
}