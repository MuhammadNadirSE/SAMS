using System;

namespace TMD.Models.DomainModels
{
    public class BillDetail
    {
        public int BillDetailId { get; set; }
        public long ClientId { get; set; }
        public Nullable<System.DateTime> BillIssueDate { get; set; }
        public Nullable<long> ServiceNumber { get; set; }
        public Nullable<int> BillDetailServiceTypeId { get; set; }
        public Nullable<int> BillDetailChargeTypeId { get; set; }
        public string Description { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> InclGst { get; set; }
        public long BatchId { get; set; }

        public virtual Client Client { get; set; }
        public virtual BillDetailServiceType BillDetailServiceType { get; set; }
        public virtual BillDetailChargeType BillDetailChargeType { get; set; }
        public virtual ImportBatch ImportBatch { get; set; }
    }
}
