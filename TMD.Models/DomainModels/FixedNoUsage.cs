using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class FixedNoUsage
    {
        public long FixedNoUsageId { get; set; }
        public Nullable<long> ServiceNumber { get; set; }
        public Nullable<decimal> SumOfInclGst { get; set; }
        public long BatchId { get; set; }

        public virtual ImportBatch ImportBatch { get; set; }
    }
}
