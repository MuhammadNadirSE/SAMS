using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
     public interface IDesignationService 
     {

         IEnumerable<Designation> GetAllDesignations();
     }
}
