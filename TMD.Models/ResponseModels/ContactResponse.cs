using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class ContactResponse
    {
        public ContactResponse()
        {
            Contacts=new List<Contact>();
        }

        public Contact Contact { get; set; }
        public IEnumerable<Address> Addresses { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }


        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public int FilteredCount { get; set; }

    }
}
