using System;
using TMD.Models.DomainModels;

namespace TMD.Models.Resources
{
    public class PayRollGroupByModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal TotalAllowances { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime AllowanceDate { get; set; }
        public virtual AllowanceType AllowanceType { get; set; }
        public virtual Employee Employee { get; set; }
    }
}