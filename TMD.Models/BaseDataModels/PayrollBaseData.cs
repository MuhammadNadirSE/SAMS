using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.BaseDataModels
{
    public class PayrollBaseData
    {
        public PayrollBaseData()
        {
            EmployeePayrolls = new List<EmployeePayroll>();
        }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<EmployeePayroll> EmployeePayrolls { get; set; }
        public EmployeePayroll Payroll { get; set; }
        public IEnumerable<AllowanceType> AllowanceTypes { get; set; }
    }
}