using System;
using System.Linq;
using TMD.Models.DomainModels;
using TMD.Web.ViewModels.Employee;

namespace TMD.Web.ModelMappers
{
    public static class EmployeeMapper
    {
        public static EmployeeModel CreateFromServerToClient(this Employee source, int GMT)
        {
            
            var employee= new EmployeeModel
            {
                FullName = source.FullName,
               
                BankAccountNumber = source.BankAccountNumber,
                BankAccountTitle = source.BankAccountTitle,
                BankName = source.BankName,
                Address = source.Address,
                CNIC = source.CNIC,
                CellNumber = source.CellNumber,
                DesignationId = source.DesignationId,
                DesignationTitle = source.Designation.Title,
             
                EmployeeId = source.EmployeeId,
                UserId = source.UserId,
                AllowedAnnualCasualLeaves = source.AllowedAnnualCasualLeaves,
                AllowedAnnualMedicalLeaves = source.AllowedAnnualMedicalLeaves,
                AllowedAnnualPaidLeaves = source.AllowedAnnualPaidLeaves,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDt = Utility.ConvertTimeByGMT(GMT,source.RecCreatedDt),
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDt = Utility.ConvertTimeByGMT(GMT, source.RecLastUpdatedDt),
                Salary = source.Salary
            };
            if (source.AspNetUser != null)
            {
                var role = source.AspNetUser.AspNetRoles.FirstOrDefault();
                employee.Email = source.AspNetUser.Email;
                employee.UserName = source.AspNetUser.UserName;
                employee.RoleTitle = role.Name;
                employee.RoleId = role.Id;
                employee.IsRegistered = !source.AspNetUser.LockoutEnabled;
            }
            return employee;
        }

        public static Employee CreateFromClientToServer(this EmployeeModel source)
        {
            return new Employee
            {
                FullName = source.FullName,
                BankAccountNumber = source.BankAccountNumber,
                BankAccountTitle = source.BankAccountTitle,
                CNIC = source.CNIC,
                CellNumber = source.CellNumber,
                DesignationId = source.DesignationId,
                EmployeeId = source.EmployeeId,
                UserId = source.UserId,
                BankName = source.BankName,
                Address = source.Address,
                AllowedAnnualCasualLeaves = source.AllowedAnnualCasualLeaves,
                AllowedAnnualMedicalLeaves = source.AllowedAnnualMedicalLeaves,
                AllowedAnnualPaidLeaves = source.AllowedAnnualPaidLeaves,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDt = source.RecCreatedDt,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDt = source.RecLastUpdatedDt,
                Salary = source.Salary
            };
        }

        public static EmployeeDDL MapEmployeeDdlFromServerToClient(this Employee soorce)
        {
            return new EmployeeDDL
            {
                EmployeeId = soorce.EmployeeId,
                FullName = soorce.FullName
            };
        }
    }
}