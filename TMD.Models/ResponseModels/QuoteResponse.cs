using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class QuoteResponse
    {
        public QuoteResponse()
        {
            Quotes = new List<Quote>();
        }

        public Quote Quote { get; set; }
        //Base Data
        public IEnumerable<Exclusion> Exclusions { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductModel> ProductModels { get; set; }

        public IEnumerable<Quote> Quotes { get; set; }

        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public int FilteredCount { get; set; }
    }
}
