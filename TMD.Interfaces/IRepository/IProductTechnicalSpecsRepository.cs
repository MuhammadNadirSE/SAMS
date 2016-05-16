using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IProductTechnicalSpecsRepository : IBaseRepository<ProductTechSpec, int>
    {
        IEnumerable<ProductTechSpec> LoadTechnicalSpecsByModelId(int productModelId);
    }
}
