using System;

namespace TMD.Models.DomainModels
{
    public class Leave
    {
        public long LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime LeaveAppliedFrom { get; set; }
        public DateTime LeaveAppliedTo { get; set; }
        public string ApplicationDescription { get; set; }
        public DateTime? LeaveApprovedFrom { get; set; }
        public DateTime? LeaveApprovedTo { get; set; }
        public int LeaveApprovedBy { get; set; }
        public DateTime? LeaveApprovedDate { get; set; }
        public DateTime? EditedDateTime { get; set; }
        public string Comments { get; set; }
        public int LeaveTypeId { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public DateTime RecLastUpdatedDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Employee ApprovedByEmployee { get; set; }
    }
}
