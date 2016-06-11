using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TMD.Models.DomainModels;

namespace TMD.Web.Models
{
    public class Product
    {
        public Product()
        {
            Documents = new List<Document>();
        }
        public int ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }

        [Display(Name = "Short Description")]
        [Required(ErrorMessage = "Short Description is required.")]
        [StringLength(100)]
        public string ShortDescription { get; set; }

        [Display(Name = "Detail Description")]
        public string DetailDescription { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Product Category is required.")]
        public int ProductCategoryID { get; set; }

        public List<Document> Documents { get; set; }

        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
    }
}