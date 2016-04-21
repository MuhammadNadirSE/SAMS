using System;
using System.Collections.Generic;
using TMD.Web.Models;
using TMD.Web.ViewModels.Employee;

namespace TMD.Web.ViewModels.Ticket
{
    public class TicketReplyViewModel
    {
       
        public int TicketId { get; set; }
        public string TicketReply { get; set; }
        public string TicketRepliedBy { get; set; }
        public int Status { get; set; }
        public float WorkingDays { get; set; }

        public DateTime? LeaveApprovedFrom { get; set; }
        public DateTime? LeaveApprovedTo { get; set; }
        public DateTime? LeaveApprovedDate { get; set; }
        public int? LeaveApprovedBy { get; set; }

        public bool replyConfirmationStatus { get; set; }
    }
}