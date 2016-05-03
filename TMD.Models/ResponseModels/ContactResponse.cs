using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class ContactResponse
    {
        public Contact Contact { get; set; }
        public IEnumerable<Address> Addresses { get; set; }

    }
}
