using System;
using TMD.Models.Common;

namespace TMD.Models.RequestModels
{
    public class PayrollSearchRequest : GetPagedListRequest
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }

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
