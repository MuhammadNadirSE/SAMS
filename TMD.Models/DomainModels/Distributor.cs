using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class Distributor
    {
        public int DistributorId { get; set; }
        public string DistributorName { get; set; }
        public string DistributorLink { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
