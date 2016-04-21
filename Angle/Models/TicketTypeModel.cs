using System;
using System.ComponentModel.DataAnnotations;
using TMD.Models.Common;

namespace TMD.Web.Models
{
    public class TicketTypeModel
    {
        public int TicketTypeId { get; set; }
        
        [Display(Name = "Ticket Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string TicketTitle { get; set; }

        [Display(Name = "Description")]
        public string TicketDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsLeave { get; set; }
        public int? LeaveType { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedOn { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public DateTime RecLastUpdateOn { get; set; }

        [Range(0, 5, ErrorMessage = "Select a LeaveType")]
        public LeaveType? LeaveTypes { get; set; }
    }
}