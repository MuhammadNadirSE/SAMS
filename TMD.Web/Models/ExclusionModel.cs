using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class ExclusionModel
    {
        public int ExclusionId { get; set; }

        [Display(Name = "Exclusion Description")]
        [Required(ErrorMessage = "Exclusion Description is required.")]
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
    }
}