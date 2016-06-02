using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class QuoteModel
    {
        public QuoteModel()
        {
            QuoteDetail=new QuoteDetailModel();
            QuoteExclusions=new List<QuoteExclusionModel>();
        }
        public int QuoteID { get; set; }
        [Display(Name = "Quote Ref. No.")]
        [Required(ErrorMessage = "Quote Ref. No. is required.")]
        public string QuoteReferenceNo { get; set; }
        [Display(Name = "Quote Subject")]
        [Required(ErrorMessage = "Quote Subject is required.")]
        public string Subject { get; set; }
        [Display(Name = "Payment Terms")]
        public string PaymentTerms { get; set; }
        [Display(Name = "Delivery Terms")]
        public string DeliveryTerms { get; set; }
        [Display(Name = "Installation Terms")]
        public string InstallationTerms { get; set; }
        [Display(Name = "Free Service Terms")]
        public string FreeServiceTerms { get; set; }
        [Display(Name = "Warranty Terms")]
        public string WarrantyTerms { get; set; }
        [Display(Name = "Validity Terms")]
        public string ValidityTerms { get; set; }
        
        public string CreatedBy { get; set; }
        [Display(Name = "Date")]
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }

        public Nullable<int> InquiryId { get; set; }
        [Display(Name = "Contact")]
        [Required(ErrorMessage = "Contact is required.")]
        public Nullable<int> ContactId { get; set; }

        public string ContactName { get; set; }

        public QuoteDetailModel QuoteDetail { get; set; }
        public List<QuoteExclusionModel> QuoteExclusions { get; set; }
    }
}