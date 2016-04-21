using System;

namespace TMD.Web.Models
{
    public class AttendanceWebModel
    {
        public long AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public int Status { get; set; }
        public string EmployeeName { get; set; }//For edit case only
        public string CheckInTime { get; set; }
        public string CheckInDate { get; set; }
        public string AwayFromTime { get; set; }
        public string AwayToTime { get; set; }
        public string CheckOutTime { get; set; }
        public bool IsEdited { get; set; }////For edit case only
        public int? EditedBy { get; set; }////For edit case only
        public DateTime? EditedDate { get; set; }
        public string Comments { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecCreatedDate { get; set; }

        public string WorkingHours { get; set; }
    }
}