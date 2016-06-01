using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Web.Models;

namespace TMD.Web.ViewModels.Quote
{
    public class QuoteViewModel
    {
        public QuoteViewModel()
        {
            Contacts = new List<ContactModel>();
            Products = new List<Models.Product>();
            ProductModels = new List<ProductModel>();
            Exclusions=new List<ExclusionModel>();
            QuoteExclusions = new List<QuoteExclusionModel>();
        }
        public QuoteModel Quote { get; set; }        
        //Base Data
        public List<ExclusionModel> Exclusions { get; set; }
        public List<QuoteExclusionModel> QuoteExclusions { get; set; }
        public IEnumerable<ContactModel> Contacts { get; set; }
        public IEnumerable<Models.Product> Products { get; set; }
        public IEnumerable<Models.ProductModel> ProductModels { get; set; }
    }
}