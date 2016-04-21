using System;

namespace TMD.Models.DomainModels
{
    public class EmployeePayroll
    {
        public long Id { get; set; }
        public int EmployeeId { get; set; }
        public long? AllowanceTypeId { get; set; }
        public decimal Amount { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public DateTime RecLastUpdatedDate { get; set; }
        public DateTime AllowanceMonth { get; set; }

        public virtual AllowanceType AllowanceType { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
