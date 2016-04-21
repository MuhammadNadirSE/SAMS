using System;

namespace TMD.Models.DomainModels
{
    public class Attendance
    {
        public long AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public int Status { get; set; }
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

        public virtual Employee EditedByEmployee { get; set; }
        public virtual Employee AttendeeEmployee { get; set; }
    }
}
