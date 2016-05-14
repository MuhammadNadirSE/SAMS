using System.Collections.Generic;

namespace TMD.Web.ViewModels.Product
{
    public class ProductModelViewModel
    {
        public ProductModelViewModel()
        {
            ProductCategories = new List<Models.ProductCategoryModel>();
        }
        public Models.Product Product { get; set; }
        public IList<Models.ProductCategoryModel> ProductCategories { get; set; }

    }
}