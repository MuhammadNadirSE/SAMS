
using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IExclusionService
    {
        int AddExclusion(Exclusion exclusion);
        int UpdateExclusion(Exclusion exclusion);
        IEnumerable<Exclusion> GetAllExclusions();
        Exclusion GetExclusionById(int id);

    }
}
