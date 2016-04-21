using System;
using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class AllowanceType
    {
        public long TypeId { get; set; }
        public string TypeTitle { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public DateTime RecLastUpdatedDate { get; set; }

        public virtual ICollection<EmployeePayroll> EmployeePayrolls { get; set; }
    }
}
