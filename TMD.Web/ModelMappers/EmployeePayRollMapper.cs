using System;
using TMD.Models.DomainModels;
using TMD.Models.Resources;
using TMD.Web.Models;
using TMD.Web.ViewModels.Payroll;

namespace TMD.Web.ModelMappers
{
    public static class EmployeePayRollMapper
    {
        public static EmployeePayroll CreateFromClientToServer(this EmployeePayrollModel source, string userid)
        {
            var payroll = new EmployeePayroll
            {
                Id = source.Id,
                EmployeeId = source.EmployeeId,
                Amount = source.Amount,
                AllowanceTypeId = source.AllowanceTypeId,
                AllowanceMonth = source.AllowanceMonth,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
            if (string.IsNullOrEmpty(source.RecCreatedBy))
            {
                payroll.RecCreatedBy = userid;
                payroll.RecCreatedDate=DateTime.UtcNow;
            }
            payroll.RecLastUpdatedBy = userid;
            payroll.RecLastUpdatedDate = DateTime.UtcNow;

            return payroll;
        }
        public static EmployeePayrollModel CreateFromServerToClient(this EmployeePayroll source)
        {
            return new EmployeePayrollModel
            {
                Id = source.Id,
                EmployeeId = source.EmployeeId,
                Amount = source.Amount,
                AllowanceTypeId = source.AllowanceTypeId,
                AllowanceTypeTitle = source.AllowanceType.TypeTitle,
                AllowanceMonth = source.AllowanceMonth,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                EmployeeName = source.Employee.FullName
            };
        }
        public static EmployeePayrollModel MappPayrollFromServerToClient(this EmployeePayroll source)
        {
            return new EmployeePayrollModel
            {
                Id = source.Id,
                EmployeeId = source.EmployeeId,
                Amount = source.Amount,
                AllowanceTypeId = source.AllowanceTypeId,
                AllowanceTypeTitle = source.AllowanceType.TypeTitle,
                AllowanceDate = source.AllowanceMonth.ToString("MMMM yyyy"),
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                EmployeeName = source.Employee.FullName
            };
        }

        public static PayRollListWebModel CreatePayRollFromServerToClient(this PayRollGroupByModel source)
        {
            var payroll = new PayRollListWebModel
            {
                AllowanceDate = source.AllowanceDate.ToString("MMMM yyyy"),
                EmployeeName = source.EmployeeName,
                BasicSalary = source.BasicSalary,
                EmployeeId = source.EmployeeId,
                Allowances = source.TotalAllowances,
                Total = source.TotalAmount
            };
            return payroll;
        }
    }
}