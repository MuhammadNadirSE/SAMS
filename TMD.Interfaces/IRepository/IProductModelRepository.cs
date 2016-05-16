using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IProductModelRepository : IBaseRepository<ProductModel, int>
    {
        IEnumerable<ProductModel> LoadProductModelsByProductId(int productId);
    }
}
