using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class ProcessLocalInventoryCommand : Command<ProcessLocalInventoryCommandRequest>
    {
        protected override bool CanExecute(ProcessLocalInventoryCommandRequest request)
        {
            return base.CanExecute(request);
        }

        protected override void Execute(ProcessLocalInventoryCommandRequest request)
        {
            // TO DO : Update Local Inventory: Inventory.dbo.UP_WMS_UpdateItemInventory
            // TO DO : Update WHResource.dbo.V_PackageLabel .Quantityy
        }
    }
}
