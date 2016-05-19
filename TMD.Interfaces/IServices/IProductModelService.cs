using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IProductModelService
    {
        int SaveProductModel(ProductModelResponse productModel);
        List<ProductModel> GetAllProductModelsByProductId(int productId);
        ProductModel GetProductModelById(int id);
        ProductModelResponse GetProductModelResponse(int? productId, int? modelId);
    }
}
