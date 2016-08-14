using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.BaseDataModels
{
    public class EmployeeBaseData
    {
        public Employee Employee { get; set; }
        public IEnumerable<Designation> Designation { get; set; }
        public IEnumerable<EmployeeSupervisor> EmployeeSupervisors { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<AspNetRole> Role { get; set; }
        public Document EmployeePhoto { get; set; }

        public double RemainingMedicalLeaves { get; set; }
        public double RemainingCasualLeaves { get; set; }
        public double RemainingPaidLeaves { get; set; }
    }
}
