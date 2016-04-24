using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class ProductCategoryModel
    {
        public int ProductCategoryID { get; set; }
        public string CatName { get; set; }
        public string ShortDescription { get; set; }
        public string DetailDescription { get; set; }
        public bool? IsParent { get; set; }
        public int? ParentCatID { get; set; }
    }
}