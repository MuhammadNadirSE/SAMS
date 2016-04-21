using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.Resources;

namespace TMD.Models.ResponseModels
{
    public class PayrollResponse
    {
        public PayrollResponse()
        {
            EmployeePayrolls = new List<EmployeePayroll>();
            EmployeePayrollGroupBy = new List<PayRollGroupByModel>();
        }

        public IEnumerable<EmployeePayroll> EmployeePayrolls { get; set; }
        public IEnumerable<PayRollGroupByModel> EmployeePayrollGroupBy { get; set; }

        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public int FilteredCount { get; set; }
    }
}
