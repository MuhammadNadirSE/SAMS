using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
     public interface IDesignationService 
     {
         int AddDesignation(Designation designation);
         int UpdateDesignation(Designation designation);
         Designation GetDesignationById(int id);
         IEnumerable<Designation> GetAllDesignations();
     }
}
