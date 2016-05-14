
using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface ITechnicalSpecsService
    {
        int AddTechnicalSpecs(TechnicalSpec productCategory);
        int UpdateTechnicalSpecs(TechnicalSpec productCategory);
        IEnumerable<TechnicalSpec> GetAllTechnicalSpecs();
        TechnicalSpec GetPTechnicalSpecsById(int id);
     
    }
}
