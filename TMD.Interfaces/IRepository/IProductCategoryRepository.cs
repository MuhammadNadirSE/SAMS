using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory,int>
    {
        IEnumerable<ProductCategory> GetAllLeafCategories();
    }
}
