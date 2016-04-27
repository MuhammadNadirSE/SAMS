using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class SeedValue
    {
        public int SeedValueID { get; set; }
        public int SeedID { get; set; }
        public string ValueCode { get; set; }
        public int ValueId { get; set; }
        public string Description { get; set; }

        public virtual Seed Seed { get; set; }
    }
}
