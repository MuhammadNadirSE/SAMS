using System;

namespace TMD.Web.Models
{
    public class TicketModel
    {
        public long TicketId { get; set; }
        public string TicketReply { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string DateFromString { get; set; }
        public string DateToString { get; set; }
        public string Reason { get; set; }
        public int TicketTypeId { get; set; }
        public bool IsTicketLeaveType { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedOn { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public DateTime RecLastUpdateOn { get; set; }

        public DateTime ? LeaveApprovedFrom { get; set; }
        public DateTime? LeaveApprovedTo { get; set; }
        public DateTime? LeaveApprovedDate { get; set; }
        public int? LeaveApprovedBy { get; set; }
        public double WorkingDays { get; set; }

        public int EmployeeId { get; set; }
        public int StatusId { get; set; }
        public string EmployeeName { get; set; }
        public string TicketTitle { get; set; }
        public string ButtonColor { get; set; }

        public int RemainingMedicalLeaves { get; set; }
        public int AllowedMedicalLeaves { get; set; }

        public int AllowedCasualLeaves { get; set; }
        public int RemainingCasualLeaves { get; set; }

        public int RemainingPaidLeaves { get; set; }
        public int AllowedPaidLeaves { get; set; }
    }
}