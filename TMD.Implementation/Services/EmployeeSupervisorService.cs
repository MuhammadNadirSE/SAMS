using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
     public   class EmployeeSupervisorService : IEmployeeSupervisorService
    {

        #region 'Private and Constructor'
        private readonly IEmployeeSupervisorRepository EmployeeSupervisorRepository;


        public EmployeeSupervisorService(IEmployeeSupervisorRepository EmployeeSupervisorRepository)
        {
            this.EmployeeSupervisorRepository = EmployeeSupervisorRepository;
            
        }

      

        #endregion 'Private and Constructor'

        public IEnumerable<EmployeeSupervisor> GetAllEmployeesSupervisors()
        {
            return EmployeeSupervisorRepository.GetAll();
        }
    }
}
