using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class MobileDetail
    {
        public int MobileDetailId { get; set; }
        public Nullable<long> ClientId { get; set; }
        public Nullable<System.DateTime> BillIssueDate { get; set; }
        public Nullable<long> ServiceNumber { get; set; }
        public Nullable<int> ServiceTypeId { get; set; }
        public Nullable<int> ChargeTypeId { get; set; }
        public string Description { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> InclGst { get; set; }
        public long BatchId { get; set; }

        public virtual BillDetailChargeType BillDetailChargeType { get; set; }
        public virtual BillDetailServiceType BillDetailServiceType { get; set; }
        public virtual Client Client { get; set; }
        public virtual ImportBatch ImportBatch { get; set; }
    }
}
