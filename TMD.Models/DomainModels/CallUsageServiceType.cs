using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class CallUsageServiceType
    {
        public int CallUsageServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceTypeDescription { get; set; }
        public bool IsManuallyCreated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CallUsageItemisation> CallUsageItemisations { get; set; }
    }
}
