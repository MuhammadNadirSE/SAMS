using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.BaseDataModels;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.Resources;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class EmployeePayrollService : IEmployeePayrollService
    {
        #region Private
        private readonly IEmployeePayrollRepository payrollRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IAllowanceTypeRepository allowanceTypeRepository;
        #endregion

        #region Constructor
        public EmployeePayrollService(IEmployeePayrollRepository payrollRepository, IEmployeeRepository employeeRepository, IAllowanceTypeRepository allowanceTypeRepository)
        {
            this.payrollRepository = payrollRepository;
            this.employeeRepository = employeeRepository;
            this.allowanceTypeRepository = allowanceTypeRepository;
        }

        #endregion

        #region Public
        public PayrollBaseData GetPayrollData(int? Eid, DateTime? M)
        {
            var id = Convert.ToInt32(ConfigurationManager.AppSettings["BasicSalaryId"]);
            var baseData = new PayrollBaseData
            {
                Employees = employeeRepository.GetAll(),
                AllowanceTypes = allowanceTypeRepository.GetAll().Where(x => x.TypeId != id),
                
            };
            if (Eid != null && M != null)
            {
                baseData.EmployeePayrolls = payrollRepository.GetPayrollByEmployeeId((int) Eid,(DateTime)M).ToList();
            }
            return baseData;
        }

        

        public IEnumerable<EmployeePayroll> GetCurrentDatePayrollData()
        {
            return payrollRepository.GetCurrentDatePayrollData();
        }

        public bool SaveUpdate(IEnumerable<EmployeePayroll> employeePayrolls)
        {
            foreach (var employeePayroll in employeePayrolls)
            {
                payrollRepository.Update(employeePayroll);
            }
            payrollRepository.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var itemToDelete = payrollRepository.Find(id);
            
            if(itemToDelete == null)
                return false;

            payrollRepository.Delete(itemToDelete);
            payrollRepository.SaveChanges();
            return true;
        }

        public PayrollResponse GetAllPayrolls(PayrollSearchRequest searchRequest)
        {
            var payrolls =  payrollRepository.GetAllPayrolls(searchRequest);
            return payrolls;
        }

        #endregion
    }
}
