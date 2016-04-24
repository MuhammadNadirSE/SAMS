using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IProductCategoryService
    {
        public int AddCategory(ProductCategory productCategory);
        public int UpdateCategory(ProductCategory productCategory);
        public IEnumerable<ProductCategory> GetAllCategories();
        public ProductCategory GetProductCategoryById(int id);
        public ProductCategoryResponse GetProductCategoryResponse(int? id);




    }
}
