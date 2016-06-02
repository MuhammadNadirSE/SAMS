using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels.Quote
{
    public class QuotePrintViewModel
    {
        public QuoteModel Quote { get; set; }        
        //Base Data
        public ContactModel Contact { get; set; }
        public Models.Product Product { get; set; }
        public ProductModel ProductModel { get; set; }
        public List<ProductTechnicalSpec> ProductModelTechnicalSpec { get; set; }
    }
}