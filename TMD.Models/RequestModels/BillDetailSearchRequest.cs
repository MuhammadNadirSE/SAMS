using System;
using TMD.Models.Common;

namespace TMD.Models.RequestModels
{
    public class BillDetailSearchRequest : GetPagedListRequest
    {
        public int BillDetailId { get; set; }
        public long AccountNumber { get; set; }
        public DateTime BillIssueDate { get; set; }
        public long? ServiceNumber { get; set; }
        public string ServiceType { get; set; }
        public string ChargeType { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? InclGst { get; set; }

        public BillDetailByColumn BillDetailByColumn
        {
            get
            {
                return (BillDetailByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
