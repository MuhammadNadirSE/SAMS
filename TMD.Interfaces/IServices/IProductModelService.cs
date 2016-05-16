using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IProductModelService
    {
        int SaveProductModel(ProductModel productModel);
        IEnumerable<ProductModel> GetAllProductModelsByProductId(int productId);
        Product GetProductModelById(int id);
        ProductModelResponse GetProductModelResponse(int? modelId);
    }
}
