using System;
using TMD.Models.Common;

namespace TMD.Models.RequestModels
{
    public class InquirySearchRequest : GetPagedListRequest
    {
        public string ContactName { get; set; }
        public int Priority { get; set; }
        public string CreatedBy { get; set; }

        public OrderByColumnInquiry OrderByColumn
        {
            get
            {
                return (OrderByColumnInquiry)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
