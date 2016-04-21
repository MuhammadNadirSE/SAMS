using System;

namespace TMD.Web.ViewModels.Payroll
{
    public class EmployeePayrollModel
    {
        public long Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public long? AllowanceTypeId { get; set; }
        public string AllowanceTypeTitle { get; set; }
        public decimal Amount { get; set; }
        public DateTime AllowanceMonth { get; set; }
        public String AllowanceDate { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public DateTime RecLastUpdatedDate { get; set; }
    }
}