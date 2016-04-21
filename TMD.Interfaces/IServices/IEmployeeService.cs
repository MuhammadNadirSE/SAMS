using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.BaseDataModels;

namespace TMD.Interfaces.IServices
{
     public interface  IEmployeeService
     {
         IEnumerable<Employee> GetAllEmployees();

        EmployeeBaseData GetEmployeeData(int? employeeId);
        bool SaveEmployee(EmployeeBaseData employee);
     }
}
