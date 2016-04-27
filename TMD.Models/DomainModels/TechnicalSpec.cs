using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class TechnicalSpec
    {
        public int TechnicalSpecId { get; set; }
        public string SpecName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }

        public virtual AspNetUser UpdatedByUser { get; set; }
        public virtual AspNetUser CreatedByUser { get; set; }
        
        public virtual ICollection<ProductTechSpec> ProductTechSpecs { get; set; }
    }
}
