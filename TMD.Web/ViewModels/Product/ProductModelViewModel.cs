using System.Collections.Generic;

namespace TMD.Web.ViewModels.Product
{
    public class ProductModelViewModel
    {
        public ProductModelViewModel()
        {
            TechnicalSpecs = new List<Models.TechnicalSpecsModel>();
        }
        public Models.ProductModel ProductModel { get; set; }
        public IList<Models.TechnicalSpecsModel> TechnicalSpecs { get; set; }

    }
}