using System;

namespace TMD.Web.Models
{
    public class Charge
    {
        public long ChargeId { get; set; }
        public long CaseId { get; set; }
        public string ChargeDescription { get; set; }
        public string ChargeLevel { get; set; }
        public DateTime? DispositionDate { get; set; }
        public string Disposition { get; set; }
    }
}