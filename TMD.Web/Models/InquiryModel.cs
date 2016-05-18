using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class InquiryModel
    {
        public int InquiryID { get; set; }
        [Display(Name = "Product")]
        [Required(ErrorMessage = "Product is required.")]
        public int InquiryProductId { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name is required.")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact")]
        [Required(ErrorMessage = "Please select contact.")]
        public int ContactID { get; set; }

        [Display(Name = "Contact Date")]
        public System.DateTime InquiryDate { get; set; }


        public int Priority { get; set; }
        public TMD.Common.Priority PriorityName { get; set; }

        [Display(Name = "Contact Response")]
        public string ContactResponse { get; set; }

        [Display(Name = "Comments")]
        public string UserComments { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdateDate { get; set; }

        public string ContactName { get; set; }
    }
}