using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public partial class Exclusion
    {
        public int ExclusionId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }

        public virtual AspNetUser UpdatedByUser { get; set; }
        public virtual AspNetUser CreatedByUser { get; set; }
        public virtual ICollection<QuoteExclusion> QuoteExclusions { get; set; }
    }
}
