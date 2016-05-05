using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.RequestModels;
using TMD.Web.Models;



namespace TMD.Web.ViewModels.Contact
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            Addresses = new List<AddressModel>();
        }
        public ContactModel Contact { get; set; }
        public IList<AddressModel> Addresses { get; set; }


        public List<ContactModel> data { get; set; }
        public ContactSearchRequest ContactSearchRequest { get; set; }

        /// <summary>
        /// Total Records in DB
        /// </summary>
        public int recordsTotal;

        /// <summary>
        /// Total Records Filtered
        /// </summary>
        public int recordsFiltered;
    }
}