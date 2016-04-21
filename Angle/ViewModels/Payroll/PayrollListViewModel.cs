using System.Collections.Generic;
using TMD.Models.RequestModels;
using TMD.Web.Models;
using TMD.Web.ViewModels.Employee;

namespace TMD.Web.ViewModels.Payroll
{
    public class PayrollListViewModel
    {
        public PayrollListViewModel()
        {
            //EmployeePayrolls=new List<EmployeePayrollModel>();
            PayrollSearchRequest = new PayrollSearchRequest();
            data = new List<PayRollListWebModel>();
        }
        public List<EmployeeModel> Employees { get; set; }
        //public List<EmployeePayrollModel> EmployeePayrolls { get; set; }
        //public PayRollListWebModel EmployeePayroll { get; set; }
        public List<PayRollListWebModel> data { get; set; }
        public PayrollSearchRequest PayrollSearchRequest { get; set; }

        /// <summary>
        /// Total Records in DB
        /// </summary>
        public int recordsTotal;

        /// <summary>
        /// Total Records Filtered
        /// </summary>
        public int recordsFiltered;
    }
}