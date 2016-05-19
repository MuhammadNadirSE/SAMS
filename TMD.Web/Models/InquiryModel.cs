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

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Inquiry Title is required.")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact")]
        [Required(ErrorMessage = "Please select contact.")]
        public int ContactID { get; set; }

        [Display(Name = "Contact Date")]
        public System.DateTime InquiryDate { get; set; }

        [Display(Name = "Priority")]
        [Required(ErrorMessage = "Please select priority.")]
        public int Priority { get; set; }
        public string PriorityName { get; set; }

        [Display(Name = "Contact Response")]
        [Required(ErrorMessage = "Contact response is required.")]
        public string ContactResponse { get; set; }

        [Display(Name = "Comments")]
        [Required(ErrorMessage = "Comments are required.")]
        public string UserComments { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdateDate { get; set; }

        public string ContactName { get; set; }
    }
}