using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IRepository
{
    public interface IEmployeePayrollRepository : IBaseRepository<EmployeePayroll, long>
    {
        EmployeePayroll GetPayroll();
        IEnumerable<EmployeePayroll>GetCurrentDatePayrollData();
        IEnumerable<EmployeePayroll>GetPayrollByEmployeeId(int employeeId, DateTime month);
        PayrollResponse GetAllPayrolls(PayrollSearchRequest payrollSearchRequest);
    }
}
