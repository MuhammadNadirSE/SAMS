using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class QuoteModel
    {
        public int QuoteID { get; set; }
        public string QuoteReferenceNo { get; set; }
        public string Subject { get; set; }
        public string PaymentTerms { get; set; }
        public string DeliveryTerms { get; set; }
        public string InstallationTerms { get; set; }
        public string FreeServiceTerms { get; set; }
        public string WarrantyTerms { get; set; }
        public string ValidityTerms { get; set; }
        
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }

        public Nullable<int> InquiryId { get; set; }
        public Nullable<int> ContactId { get; set; }

        public QuoteDetailModel QuoteDetail { get; set; }
        public List<QuoteExclusionModel> QuoteExclusions { get; set; }
    }
}