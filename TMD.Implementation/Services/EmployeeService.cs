using System;
using System.Collections.Generic;
using System.Linq;
using TMD.Common;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.BaseDataModels;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
     public   class EmployeeService : IEmployeeService
    {

        #region 'Private and Constructor'

         private readonly IDocumentService documentService;
         private readonly IDocumentRepository documentRepository;
         private readonly IEmployeeRepository employeeRepository;
         private readonly IDesignationRepository designationRepository;
         private readonly IEmployeeSupervisorRepository employeeSupervisorRepository;
         private readonly IAspNetRoleRepository aspNetRoleRepository;
         private readonly ITicketRepository ticketRepository;

         public EmployeeService(IDocumentService documentService,IDocumentRepository documentRepository,IEmployeeRepository EmployeeRepository,IDesignationRepository designationRepository,IEmployeeSupervisorRepository employeeSupervisorRepository,IAspNetRoleRepository aspNetRoleRepository, ITicketRepository ticketRepository)
         {
             this.documentService = documentService;
             this.documentRepository = documentRepository;
             this.employeeRepository = EmployeeRepository;
             this.designationRepository = designationRepository;
             //this.employeeSupervisorRepository = employeeSupervisorRepository;
             this.aspNetRoleRepository = aspNetRoleRepository;
             //this.ticketRepository = ticketRepository;
         }

         #endregion 'Private and Constructor'

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAll();
        }

        public EmployeeBaseData GetEmployeeData(int? employeeId)
        {
            EmployeeBaseData baseData = new EmployeeBaseData();
            if (employeeId != null)
            {
                var empId = (int) employeeId;
                baseData.Employee = employeeRepository.Find(empId);
                baseData.EmployeePhoto =
                    documentRepository.GetAllDocumentByRefId(empId, (int) DocumentType.EmployeePhoto).FirstOrDefault();
            }
                
            baseData.Designation = designationRepository.GetAll();

            baseData.Role = aspNetRoleRepository.GetAll();

            return baseData;

            
        }

        public bool SaveEmployee(EmployeeBaseData employeeData)
         {
             if (employeeData.Employee.EmployeeId > 0)
             {
                 employeeRepository.Update(employeeData.Employee);
             }
             else
             {
                 employeeRepository.Add(employeeData.Employee);
             }
            if (employeeData.EmployeePhoto != null)
                documentService.AddDocument(employeeData.EmployeePhoto, employeeData.Employee.EmployeeId, DocumentType.EmployeePhoto);
            employeeRepository.SaveChanges();

            //SaveEmployeeSupervisors(employeeData);

            return true;
         }

         private void SaveEmployeeSupervisors(EmployeeBaseData employeeData)
         {
             if (employeeData.Employee.EmployeeId > 0)
             {
                 var supervisors = employeeSupervisorRepository.GetSupervisorsByEmployeeId(employeeData.Employee.EmployeeId);

                 foreach (var employeeSupervisors in supervisors)
                 {
                     employeeSupervisorRepository.Delete(employeeSupervisors);
                 }
                 //employeeSupervisorRepository.SaveChanges();
             }
             if (employeeData.EmployeeSupervisors != null && employeeData.EmployeeSupervisors.Any())
             {
                 foreach (var employeeSupervisor in employeeData.EmployeeSupervisors)
                 {
                     employeeSupervisor.EmployeeId = employeeData.Employee.EmployeeId;

                     employeeSupervisorRepository.Add(employeeSupervisor);
                 }
             }
             employeeSupervisorRepository.SaveChanges();
         }
    }
}
