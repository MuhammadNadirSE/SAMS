namespace TMD.Models.DomainModels
{
    using System;
    using System.Collections.Generic;
    
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string DetailDescription { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }

        public virtual AspNetUser CreatedByUser { get; set; }
        public virtual AspNetUser UpdatedByUser { get; set; }

        public virtual ICollection<InquiryDetail> InquiryDetails { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ICollection<ProductModel> ProductModels { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
