using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class ProductCategoryResponse
    {
        public ProductCategory ProductCategory { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }

    }
}
