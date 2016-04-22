using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class Seed
    {
        public int SeedID { get; set; }
        public string SeedCode { get; set; }
        public string ValueCode { get; set; }
        public Nullable<int> Value { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SeedValue> SeedValues { get; set; }
    }
}
