using System;
using TMD.Models.Common;

namespace TMD.Models.RequestModels
{
    public class AttendanceSearchRequest : GetPagedListRequest
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }

        public OrderByColumnAttendance OrderByColumn
        {
            get
            {
                return (OrderByColumnAttendance)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
