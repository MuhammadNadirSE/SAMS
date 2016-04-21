using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class TicketType
    {
        public int TicketTypeId { get; set; }
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsLeave { get; set; }
        public int? LeaveType { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedOn { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdateOn { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
