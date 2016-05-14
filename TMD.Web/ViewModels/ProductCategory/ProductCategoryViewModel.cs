using System.Collections.Generic;
using TMD.Web.Models;



namespace TMD.Web.ViewModels.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public ProductCategoryViewModel()
        {
            ProductCategories = new List<ProductCategoryModel>();
        }
        public ProductCategoryModel ProductCategory { get; set; }
        public IList<ProductCategoryModel> ProductCategories { get; set; }

    }
}