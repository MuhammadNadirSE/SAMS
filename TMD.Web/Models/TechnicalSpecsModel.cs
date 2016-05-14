using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class TechnicalSpecsModel
    {
        public int TechnicalSpecId { get; set; }

        [Display(Name = "Specification Name")]
        [Required(ErrorMessage = "Specification Name is required.")]
        public string SpecName { get; set; }

        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
    }
}