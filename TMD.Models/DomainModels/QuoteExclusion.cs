using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class QuoteExclusion
    {
        public int QuoteExclusionId { get; set; }
        public int QuoteId { get; set; }
        public int ExclusionId { get; set; }

        public virtual Exclusion Exclusion { get; set; }
        public virtual Quote Quote { get; set; }
    }
}
