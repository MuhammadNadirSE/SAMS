using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class TicketReplyResponse
    {
        public int TicketId { get; set; }
        public string TicketReply { get; set; }
        public string TicketRepliedBy { get; set; }
        public int Status { get; set; }

        public DateTime? LeaveApprovedFrom { get; set; }
        public DateTime? LeaveApprovedTo { get; set; }
        public DateTime? LeaveApprovedDate { get; set; }
        public int? LeaveApprovedBy { get; set; }
        public double WorkingDays { get; set; }
    }
}
