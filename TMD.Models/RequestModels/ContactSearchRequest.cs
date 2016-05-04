using System;
using TMD.Models.Common;

namespace TMD.Models.RequestModels
{
    public class ContactSearchRequest : GetPagedListRequest
    {
        public string ContactName { get; set; }
        public string CellNo { get; set; }
        public string EmailId { get; set; }

        public OrderByColumnPayroll OrderByColumn
        {
            get
            {
                return (OrderByColumnPayroll)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
