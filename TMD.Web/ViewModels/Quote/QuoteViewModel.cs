using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Web.Models;

namespace TMD.Web.ViewModels.Quote
{
    public class QuoteViewModel
    {
        public QuoteModel Quote { get; set; }        
        //Base Data
        public ExclusionModel Exclusions { get; set; }
        public IEnumerable<ContactModel> Contacts { get; set; }
        public IEnumerable<Models.Product> Products { get; set; }
        public IEnumerable<Models.ProductModel> ProductModels { get; set; }
    }
}