using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class ServiceEquipmentServiceType
    {
        public int ServiceEquipmentTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceTypeDescription { get; set; }
        public bool IsManuallyCreated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceEquipment> ServiceEquipments { get; set; }
    }
}
