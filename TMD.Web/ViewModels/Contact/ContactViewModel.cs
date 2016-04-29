using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

    }
}