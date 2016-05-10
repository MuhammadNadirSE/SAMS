using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Web.Models;

namespace TMD.Web.ViewModels.Product
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductCategories = new List<ProductCategoryModel>();
        }
        public ProductModel Product { get; set; }
        public IList<ProductCategoryModel> ProductCategories { get; set; }

    }
}