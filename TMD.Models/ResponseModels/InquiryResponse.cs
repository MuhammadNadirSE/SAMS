using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class InquiryResponse
    {
        public Inquiry Inquiry { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Product> Products { get; set; }


    }
}
