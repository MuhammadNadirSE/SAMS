using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class DesignationModel
    {

        public int DesignationId { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Display(Name = "Abbreviation")]
        [Required(ErrorMessage = "Abbreviation is required.")]
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDt { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDt { get; set; }


    }
}