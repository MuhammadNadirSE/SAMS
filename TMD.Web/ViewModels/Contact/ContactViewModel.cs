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
            Contacts = new List<ContactModel>();
        }
        public ContactModel Contact { get; set; }
        public IList<ContactModel> Contacts { get; set; }

    }
}