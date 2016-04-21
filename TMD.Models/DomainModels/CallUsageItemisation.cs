using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class CallUsageItemisation
    {
        public int CallUsageId { get; set; }
        public long ClientId { get; set; }
        public Nullable<long> ServiceNumber { get; set; }
        public Nullable<int> CallUsageServiceType { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string CalledNumber { get; set; }
        public Nullable<int> CallUsageTypeId { get; set; }
        public Nullable<System.TimeSpan> Duration { get; set; }
        public string Volume { get; set; }
        public Nullable<decimal> InclGst { get; set; }
        public long BatchId { get; set; }

        public virtual CallUsageServiceType CallUsageServiceType1 { get; set; }
        public virtual CallUsageType CallUsageType { get; set; }
        public virtual Client Client { get; set; }
        public virtual ImportBatch ImportBatch { get; set; }
    }
}
