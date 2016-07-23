using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalBizCommand._03_ReceivingPostCommands
{
    public class RecivingPostInputEntity
    {

    }

    public class ReceivingPostResultEntity
    {
        public static ReceivingPostResultEntity Default
        {
            get
            {
                return new ReceivingPostResultEntity();
            }
        }
        public string OutMsg { get; set; }
    }

    public class ASNMaster
    {
    }

    public class ASNTransaction
    {

    }

    public class ASNReceivingDetail
    {

    }

    public class ASNReceivingInfoEntity
    {
        public ASNMaster Master { get; set; }
        public ASNTransaction Transactions { get; set; }
        public ASNReceivingDetail Details { get; set; }
    }

    public class ExternalPackageLabelCommandRequest
    {
        public string OrderNumber { get; set; }
        public int OrderType { get; set; }
        public int CompanyCode { get; set; }
    }

    public class ProcessLocalReceivingBatchNumberCommandRequest
    {

    }

    public class ProcessLocalInventoryCommandRequest
    {

    }

    public class ProcessGoodsReceiptNoticeCommandRequest
    {

    }

    public class ProcessActiveScanedUPCMessageCommandRequest
    {
    }

    public class ProcessWRDTaskContextCommandRequest
    {
    }

    public class ProcessWRDTaskContextCommandResponse
    {
        public bool IsSuccess { get; set; }
        public ReceivingPostResultEntity Result { get; set; }
    }

    public class ProcessInventoryBorrowCommandRequest
    {

    }

    public class ProcessInventoryBorrowCommandResponse
    {
        public bool IsSuccess { get; set; }
        public ReceivingPostResultEntity Result { get; set; }
    }

    public class ProcessLocalReceivingPostCommandRequest
    {
        public int TaskID { get; set; }

        public object Order { get; set; }
        public string OperationUserID { get; set; }
        public string WarehouseNumber { get; set; }
    }

    public class ProcessLocalReceivingPostCommandResponse
    {

    }

    public class ProcessCompleteReceivingCommandRequest
    { }
}
