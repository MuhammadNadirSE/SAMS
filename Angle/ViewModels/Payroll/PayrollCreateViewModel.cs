using System;
using System.Collections.Generic;
using TMD.Web.Models;
using TMD.Web.ViewModels.Employee;

namespace TMD.Web.ViewModels.Payroll
{
    public class PayrollCreateViewModel
    {
        public PayrollCreateViewModel()
        {
            EmployeePayrolls=new List<EmployeePayrollModel>();
        }
        public List<EmployeeModel> Employees { get; set; }
        public List<EmployeePayrollModel> EmployeePayrolls { get; set; }
        public List<AllowanceTypeModel> AllowanceTypes { get; set; }
        public decimal TotalAllowance { get; set; }
        public DateTime? AllowanceMonth { get; set; }
        public int? Eid { get; set; }
    }
}