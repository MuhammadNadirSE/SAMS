using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.RequestModels;
using TMD.Web.Models;
using TMD.Web.ViewModels.Employee;

namespace TMD.Web.ViewModels.Quote
{
    public class QuoteViewModel
    {
        public QuoteViewModel()
        {
            Contacts = new List<ContactModel>();
            Employees = new List<EmployeeDDL>();
            Products = new List<Models.Product>();
            ProductModels = new List<ProductModel>();
            Exclusions=new List<ExclusionModel>();
            QuoteExclusions = new List<QuoteExclusionModel>();
            data = new List<TMD.Web.Models.QuoteModel>();
            quoteSearchRequest = new QuoteSearchRequest();
        }
        public QuoteModel Quote { get; set; }        
        //Base Data
        public List<ExclusionModel> Exclusions { get; set; }
        public List<EmployeeDDL> Employees { get; set; }
        public List<QuoteExclusionModel> QuoteExclusions { get; set; }
        public IEnumerable<ContactModel> Contacts { get; set; }
        public IEnumerable<Models.Product> Products { get; set; }
        public IEnumerable<Models.ProductModel> ProductModels { get; set; }

        public List<TMD.Web.Models.QuoteModel> data { get; set; }
        public QuoteSearchRequest quoteSearchRequest { get; set; }

        /// <summary>
        /// Total Records in DB
        /// </summary>
        public int recordsTotal;

        /// <summary>
        /// Total Records Filtered
        /// </summary>
        public int recordsFiltered;
    }
}