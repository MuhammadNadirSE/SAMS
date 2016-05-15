using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Web.Models;

namespace TMD.Web.ViewModels.Inquiry
{
    public class InquiryViewModel
    {
        public InquiryViewModel()
        {
            Contacts = new List<ContactModel>();
            Products=new List<ProductModel>();
            InquiryDetail= new List<InquiryDetailModel>();
        }
        public InquiryModel InquiryModel { get; set; }
        public IList<ContactModel> Contacts { get; set; }
        public IList<ProductModel> Products { get; set; }

        public IList<InquiryDetailModel> InquiryDetail { get; set; }

    }
}