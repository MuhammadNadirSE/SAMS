using System;

namespace Angle.Models
{
    public class BillDetail
    {
        public int BillDetailId { get; set; }
        public long ClientId { get; set; }
        public DateTime? BillIssueDate { get; set; }
        public long? ServiceNumber { get; set; }
        public long? AccountNumber { get; set; }
        public int? BillDetailServiceTypeId { get; set; }
        public int? BillDetailChargeTypeId { get; set; }
        public string Description { get; set; }
        public string ServiceType { get; set; }
        public string ChargeType { get; set; }
        public int? Quantity { get; set; }
        public decimal? InclGst { get; set; }
        public long BatchId { get; set; }
    }
}