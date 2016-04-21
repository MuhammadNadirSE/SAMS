using System;

namespace TMD.Web.Models
{
    public class AllowanceTypeModel
    {
        public long TypeId { get; set; }
        public string TypeTitle { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public DateTime RecLastUpdatedDate { get; set; }
    }
}
