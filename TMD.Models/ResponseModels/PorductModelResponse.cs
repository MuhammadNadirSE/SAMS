using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class ProductModelResponse
    {
        public ProductModel ProductModel { get; set; }
        public IEnumerable<ProductTechSpec> ProductModelTechnicalSpec { get; set; }
        public IEnumerable<TechnicalSpec> TechnicalSpec { get; set; }
        public IEnumerable<ProductModel> ProductModels { get; set; }
    }
}
