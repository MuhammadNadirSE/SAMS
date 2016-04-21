using System;
using System.Collections.Generic;
using TMD.Web.ViewModels.Employee;

namespace TMD.Web.Models
{
    public class AttendanceModel
    {
        public AttendanceModel()
        {
            Employees = new List<EmployeeDDL>();
        }
        public long AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public int Status { get; set; }
        public string EmployeeName { get; set; } // for edit purpose
        public DateTime CheckInTime { get; set; }
        public DateTime? AwayFromTime { get; set; }
        public DateTime? AwayToTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public bool IsEdited { get; set; }
        public int? EditedBy { get; set; }
        public DateTime? EditedDate { get; set; }
        public string Comments { get; set; }
        public string IP { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public DateTime RecLastUpdatedDate { get; set; }

        public List<EmployeeDDL> Employees { get; set; } 
    }
}