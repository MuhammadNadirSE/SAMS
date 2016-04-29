using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;

namespace TMD.Web.Models
{
    public class AddressModel
    {
        public int AddressId { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please Select Country")]
        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        [Display(Name = "Address Line 1")]
        
        public string Address1 { get; set; }

         [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }
        public int ContactID { get; set; }

        [Display(Name = "Address Type")]
        public int AddressType { get; set; }

    }
}