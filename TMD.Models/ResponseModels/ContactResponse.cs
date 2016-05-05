using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;

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
