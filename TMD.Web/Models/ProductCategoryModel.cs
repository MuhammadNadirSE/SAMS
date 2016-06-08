using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class ProductCategoryModel
    {
        public int ProductCategoryID { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category Name is required.")]
        public string CatName { get; set; }

        [Display(Name = "Short Description")]
        [Required(ErrorMessage = "Category Short Description is required.")]
        [StringLength(100)]
        public string ShortDescription { get; set; }

        [Display(Name = "Detail Description")]
        public string DetailDescription { get; set; }

        [Display(Name = "Is Parent")]
        public bool IsParent { get; set; }

        [Display(Name = "Parent Category")]
        public int? ParentCatID { get; set; }

        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
    }
}