using System.Collections.Generic;

namespace TMD.Web.ViewModels.Product
{
    public class ProductModelViewModel
    {
        public ProductModelViewModel()
        {
            TechnicalSpecs = new List<Models.TechnicalSpecsModel>();
            ProductTechnicalSpec=new List<Models.ProductTechnicalSpec>();
        }
        public Models.ProductModel ProductModel { get; set; }
        public List<Models.ProductTechnicalSpec> ProductTechnicalSpec { get; set; }
        public List<Models.TechnicalSpecsModel> TechnicalSpecs { get; set; }

    }
}