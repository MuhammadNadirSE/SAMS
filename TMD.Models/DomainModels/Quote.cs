//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMD.Models.DomainModels
{
    using System;
    using System.Collections.Generic;
    
    public class Quote
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

        public virtual AspNetUser CreatedByUser { get; set; }
        public virtual AspNetUser UpdatedByUser { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Inquiry Inquiry { get; set; }
        public virtual ICollection<QuoteDetail> QuoteDetails { get; set; }
        public virtual ICollection<QuoteExclusion> QuoteExclusions { get; set; }
    }
}
