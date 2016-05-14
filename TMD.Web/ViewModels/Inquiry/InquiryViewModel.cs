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
        }
        public InquiryModel InquiryModel { get; set; }
        public IList<ContactModel> Contacts { get; set; }

    }
}