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
        public string ShortDescription { get; set; }

        [Display(Name = "Detail Description")]
        public string DetailDescription { get; set; }

        [Display(Name = "Is Parent")]
        public bool IsParent { get; set; }

        [Display(Name = "Parent Category")]
        public int? ParentCatID { get; set; }
    }
}