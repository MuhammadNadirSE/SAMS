using System;
using TMD.Models.Common;

namespace TMD.Models.RequestModels
{
    public class QuoteSearchRequest : GetPagedListRequest
    {
        public string Subject { get; set; }
        public string ReferenceNumber { get; set; }
        public string CurrentUserId { get; set; }
        public bool HasPermissionToViewAll { get; set; }

        public OrderByColumnQuote OrderByColumn
        {
            get
            {
                return (OrderByColumnQuote)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
