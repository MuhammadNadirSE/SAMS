using System.Collections.Generic;
using TMD.Models.DomainModels;
using Models = TMD.Web.Models;

namespace TMD.Web.ViewModels.Product
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductCategories = new List<Models.ProductCategoryModel>();
            Documents = new List<Document>();

        }
        public Models.Product Product { get; set; }
        public IList<Models.ProductCategoryModel> ProductCategories { get; set; }

        [Display(Name = "Upload Doc(s)")]
        public IEnumerable<System.Web.HttpPostedFileBase> UploadFiles { get; set; }
        public List<Document> Documents { get; set; }

    }
}