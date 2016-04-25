using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IProductCategoryService
    {
        int AddCategory(ProductCategory productCategory);
        int UpdateCategory(ProductCategory productCategory);
        IEnumerable<ProductCategory> GetAllCategories();
        ProductCategory GetProductCategoryById(int id);
        ProductCategoryResponse GetProductCategoryResponse(int? id);
    }
}
