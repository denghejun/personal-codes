using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class ProcessReceivingPostCommand : Command<RecivingPostInputEntity, ReceivingPostResultEntity>
    {
        protected override ReceivingPostResultEntity Execute(RecivingPostInputEntity request)
        {
            var inventoryBorrowCommandResponse = CommandProxy<ProcessInventoryBorrowCommand>.Command.Run(new ProcessInventoryBorrowCommandRequest());
            if (!inventoryBorrowCommandResponse.IsSuccess)
            {
                return inventoryBorrowCommandResponse.Result;
            }

            using (var transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                CommandProxy<ProcessLocalASNReceivingInfoCommand>.Command.Run(new ASNReceivingInfoEntity());
                CommandProxy<ProcessLocalReceivingBatchNumberCommand>.Command.Run(new ProcessLocalReceivingBatchNumberCommandRequest());
                CommandProxy<ProcessLocalInventoryCommand>.Command.Run(new ProcessLocalInventoryCommandRequest());
                CommandProxy<ProcessActiveScanedUPCMessageCommand>.Command.Run(new ProcessActiveScanedUPCMessageCommandRequest());

                CommandProxy<ProcessCompleteReceivingCommand>.Command.Run(new ProcessCompleteReceivingCommandRequest());

                CommandProxy<ProcessGoodsReceiptNoticeMessageCommand>.Command.Run(new ProcessGoodsReceiptNoticeCommandRequest());
                transaction.Complete();
            }

            return ReceivingPostResultEntity.Default;
        }
    }
}
