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
        public InquiryResponse()
        {
            Inquiries=new List<Inquiry>();
            InquiryDocuments = new List<Document>();
        }
        public Inquiry Inquiry { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<InquiryDetail> InquiryDetails { get; set; }
        public List<Document> InquiryDocuments { get; set; }


        public IEnumerable<Inquiry> Inquiries { get; set; }

        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public int FilteredCount { get; set; }
    }
}
