using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IProductService
    {
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        ProductResponse GetProductResponse(int? id);

    }
}
