using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class ProcessLocalReceivingPostCommand : Command<ProcessLocalReceivingPostCommandRequest, bool>
    {
        protected override void BeforeRun(ProcessLocalReceivingPostCommandRequest request)
        {
        }

        protected override bool CanExecute(ProcessLocalReceivingPostCommandRequest request, out bool responseWhenCanExcuteFalse)
        {
            /********************************** Throw Out Errors If Anything Verify Failed. ************************************************/

            /****** Check Part I ****
             * 1. [{0}] is not the major owner,only major owner can post!
             * 2. POR Q4S Check: a. Query Q4S failed. Can not pass the Q4S check. Post failed.
             *                             b. Post failure: Item {0} does not have enough available quantity(Q4S).
             * 3.Item [' + RTRIM(@ErrorItem) + '] does not have location. Please assign it first.
             * 4.There are {0} task(s) have NOT been completed,can NOT be posted!
             * */

            /***** Check Part II *****
             * 1. ReceivedContent can NOT be null.
             * 2. UserId can NOT be null.
             * 3. WarehouseNumber can NOT be null.
             * 4. Today is an inventory count day. You can''t post any order.
             * 5. Can NOT receive this task[id]. Its Status is not [OPEN].
             * 6. The receiving task has been posted. You can not double post it.
             * 7. WRD information has been lost,please redo WRD.
             * 8. Can NOT receive this ASN order. Its Order Status is not [OPEN].
             * 9. Warehouse [WarehouseNumber] can not receive bulk items.
             * 10. Warehouse [WarehouseNumber] can not receive small items.
             * 11. Received quantity exceeds order quantity.
             * 12. At least one Tracking Number requires.
             * 13. The total input packing quantity [ReceivingPieces] is not matched with the actual scanned quantity [SNScannedQuantity], please check.
            */

            return base.CanExecute(request, out responseWhenCanExcuteFalse);
        }
        protected override bool Execute(ProcessLocalReceivingPostCommandRequest request)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                CommandProxy<ProcessLocalASNReceivingInfoCommand>.Command.Run(new ASNReceivingInfoEntity());
                CommandProxy<ProcessExternalPackageLabelCommand>.Command.Run(new ExternalPackageLabelCommandRequest());
                CommandProxy<ProcessLocalReceivingBatchNumberCommand>.Command.Run(new ProcessLocalReceivingBatchNumberCommandRequest());
                CommandProxy<ProcessLocalInventoryCommand>.Command.Run(new ProcessLocalInventoryCommandRequest());
                CommandProxy<ProcessGoodsReceiptNoticeMessageCommand>.Command.Run(new ProcessGoodsReceiptNoticeCommandRequest());
                CommandProxy<ProcessActiveScanedUPCMessageCommand>.Command.Run(new ProcessActiveScanedUPCMessageCommandRequest());
                CommandProxy<ProcessCompleteReceivingCommand>.Command.Run(new ProcessCompleteReceivingCommandRequest());
                transaction.Complete();
            }

            return true;
        }
    }
}
