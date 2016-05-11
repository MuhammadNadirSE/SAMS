using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;

namespace TMD.Web.Models
{
    public class ProductModel
    {

        public int ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }

        [Display(Name = "Short Description")]
        [Required(ErrorMessage = "Short Description is required.")]
        public string ShortDescription { get; set; }

        [Display(Name = "Detail Description")]
        [Required(ErrorMessage = "Detail Description is required.")]
        public string DetailDescription { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Product Price is required.")]
        public decimal Price { get; set; }


        public int ProductCategoryID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }

   


    }
}