using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public  class Designation
    {
        public int DesignationId { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDt { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
