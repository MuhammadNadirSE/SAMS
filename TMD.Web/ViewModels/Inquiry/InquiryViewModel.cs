using System.Collections.Generic;
using TMD.Models.RequestModels;
using Models=TMD.Web.Models;

namespace TMD.Web.ViewModels.Inquiry
{
    public class InquiryViewModel
    {
        public InquiryViewModel()
        {
            Contacts = new List<Models.ContactModel>();
            Products=new List<Models.Product>();
            InquiryDetail= new List<Models.InquiryDetailModel>();
            data = new List<Models.InquiryModel>();
            InquirySearchRequest=new InquirySearchRequest();
        }
        public Models.InquiryModel InquiryModel { get; set; }
        public IList<Models.ContactModel> Contacts { get; set; }
        public IList<Models.Product> Products { get; set; }
        public IList<Models.InquiryDetailModel> InquiryDetail { get; set; }


        public List<Models.InquiryModel> data { get; set; }
        public InquirySearchRequest InquirySearchRequest { get; set; }

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