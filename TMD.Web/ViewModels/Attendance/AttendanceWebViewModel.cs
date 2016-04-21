using System;
using System.Collections.Generic;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Web.Models;
using TMD.Web.ViewModels.Employee;

namespace TMD.Web.ViewModels.Attendance
{
    public class AttendanceWebViewModel
    {
        public AttendanceWebViewModel()
        {
            data = new List<AttendanceWebModel>();
            AttendanceSearchRequest = new AttendanceSearchRequest();
            Employees = new List<EmployeeModel>();
        }
        public List<AttendanceWebModel> data { get; set; }
        public List<EmployeeModel> Employees { get; set; }

        public AttendanceSearchRequest AttendanceSearchRequest { get; set; }

        /// <summary>
        /// Total Records in DB
        /// </summary>
        public int recordsTotal;

        /// <summary>
        /// Total Records Filtered
        /// </summary>
        public int recordsFiltered;

        public double TotalWorkingHours { get; set; }
        public double AvgWorkingHours { get; set; }
        public int TotalWorkingDays { get; set; }
    }
}