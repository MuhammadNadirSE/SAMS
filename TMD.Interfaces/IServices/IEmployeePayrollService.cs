using System;
using System.Collections.Generic;
using TMD.Models.BaseDataModels;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IEmployeePayrollService
    {
        PayrollBaseData GetPayrollData(int? Eid, DateTime ? M);

        IEnumerable<EmployeePayroll> GetCurrentDatePayrollData();

        bool SaveUpdate(IEnumerable<EmployeePayroll> employeePayrolls);
        bool Delete(int id);

        PayrollResponse GetAllPayrolls(PayrollSearchRequest searchRequest);
    }
}
