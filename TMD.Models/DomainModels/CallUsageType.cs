using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class CallUsageType
    {
        public int CallUsageTypeId { get; set; }
        public string CallUsageTypeName { get; set; }
        public string CallUsageTypeDescription { get; set; }
        public bool IsManuallyCreated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CallUsageItemisation> CallUsageItemisations { get; set; }
    }
}
