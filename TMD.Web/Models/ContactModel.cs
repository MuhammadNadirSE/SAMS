using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class ContactModel
    {
        public int    ContactID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PrimaryPhone { get; set; }
        public string HomePhone { get; set; }
        public string Fax { get; set; }
        public string CellNo { get; set; }
        public Nullable<int> ContactType { get; set; }
        public Nullable<int> AddressId { get; set; }
        public string CompanyName { get; set; }
    }
}