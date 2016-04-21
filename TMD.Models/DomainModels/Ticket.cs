using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class Ticket
    {
        public long TicketId { get; set; }
        public string TicketReply { get; set; }
        public int StatusId { get; set; }
        public Nullable<System.DateTime> DateFrom { get; set; }
        public Nullable<System.DateTime> DateTo { get; set; }
        public string Reason { get; set; }
        public int TicketTypeId { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedOn { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdateOn { get; set; }
        public int EmployeeId { get; set; }
        public Nullable<System.DateTime> LeaveApprovedFrom { get; set; }
        public Nullable<System.DateTime> LeaveApprovedTo { get; set; }
        public Nullable<int> LeaveApprovedBy { get; set; }
        public Nullable<System.DateTime> LeaveApprovedDate { get; set; }
        public double WorkingDays { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Employee SupervisorOfEmployee { get; set; }
        public virtual TicketType TicketType { get; set; }
    }
}
