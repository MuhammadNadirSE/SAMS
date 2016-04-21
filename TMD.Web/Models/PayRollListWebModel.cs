using System;

namespace TMD.Web.Models
{
    public class PayRollListWebModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal Allowances { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Total { get; set; }
        public string AllowanceDate { get; set; }
    }
}