using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
     public interface IEmployeeSupervisorService 
     {

         IEnumerable<EmployeeSupervisor> GetAllEmployeesSupervisors();
     }
}
