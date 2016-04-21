using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Web.ViewModels.EmployeeSupervisor;
using TMD.Web.ViewModels.Designation;
using TMD.Web.ViewModels.UserRoles;


namespace TMD.Web.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Employee=new EmployeeModel();
        }
        public EmployeeModel Employee { get; set; }

        public double RemainingMedicalLeaves { get; set; }
        public double RemainingCasualLeaves { get; set; }
        public double RemainingPaidLeaves { get; set; }


        public List<DesignationModel> Designation { get; set; }
        public List<EmployeeSupervisorModel> EmployeeSupervisor { get; set; }
        public List<EmployeeModel> Employees { get; set; }
        public List<EmployeeModel> EmployeesSupervisors { get; set; }

        public List<AspNetRoleModel> Roles { get; set; }
        public string SupervisorIdsToDelete { get; set; }
    }
}
