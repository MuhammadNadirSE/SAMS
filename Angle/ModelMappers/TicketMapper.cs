using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;
using TMD.Web.Models;
using TMD.Web.ViewModels.Ticket;

namespace TMD.Web.ModelMappers
{
    public static class TicketMapper
    {
        public static Ticket MapFromClientToServer(this TicketModel source)
        {
            return new Ticket
            {
                TicketId = source.TicketId,
                RecCreatedOn = source.RecCreatedOn,
                RecLastUpdateOn = source.RecLastUpdateOn,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecCreatedBy = source.RecCreatedBy,
                TicketTypeId = source.TicketTypeId,
                DateFrom = source.DateFrom,
                DateTo = source.DateTo,
                EmployeeId = source.EmployeeId,
                Reason = source.Reason,
                StatusId = source.StatusId,
                WorkingDays = source.WorkingDays,
                LeaveApprovedDate = source.LeaveApprovedDate,
                LeaveApprovedFrom = source.LeaveApprovedFrom,
                LeaveApprovedBy = source.LeaveApprovedBy,
                LeaveApprovedTo = source.LeaveApprovedTo
            };
        }

        public static TicketModel MapFromServerToClient(this Ticket source, int GMT)
        {
            string color="";
            if (source.StatusId == 1)
                color = "btn-success";
            else if (source.StatusId == 2)
                color = "btn-danger";
            else
                color = "btn-warning";


            
            var toReturn = new TicketModel
            {
                TicketId = source.TicketId,
                StatusId = source.StatusId,
                TicketReply = source.TicketReply??"",
                RecCreatedOn = source.RecCreatedOn,
                RecLastUpdateOn = source.RecLastUpdateOn,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecCreatedBy = source.RecCreatedBy,
                TicketTypeId = source.TicketTypeId,
                DateFrom = source.DateFrom,
                DateTo = source.DateTo,
                EmployeeId = source.EmployeeId,
                Reason = source.Reason,
                EmployeeName = source.Employee.FullName,
                TicketTitle = source.TicketType.TicketTitle,
                ButtonColor = color,
                LeaveApprovedDate = source.LeaveApprovedDate,
                LeaveApprovedFrom = source.LeaveApprovedFrom,
                LeaveApprovedTo = source.LeaveApprovedTo,
                AllowedCasualLeaves = source.Employee.AllowedAnnualCasualLeaves,
                AllowedMedicalLeaves = source.Employee.AllowedAnnualMedicalLeaves,
                AllowedPaidLeaves = source.Employee.AllowedAnnualPaidLeaves,
                IsTicketLeaveType = source.TicketType.IsLeave
                
            };

            if (source.DateFrom != null && source.DateTo != null)
            {
                toReturn.DateFromString = source.DateFrom.Value.ToShortDateString();
                toReturn.DateToString = source.DateTo.Value.ToShortDateString();
            }
            
            return toReturn;
        }
        public static TicketReplyResponse MapReplyFromClientToServer(this TicketReplyViewModel source)
        {
            return new TicketReplyResponse
            {
                TicketId = source.TicketId,
                TicketRepliedBy = source.TicketRepliedBy,
                TicketReply = source.TicketReply,
                Status = source.Status,
                LeaveApprovedBy = source.LeaveApprovedBy,
                LeaveApprovedDate = source.LeaveApprovedDate,
                LeaveApprovedFrom = source.LeaveApprovedFrom,
                LeaveApprovedTo = source.LeaveApprovedTo,
                WorkingDays = source.WorkingDays
            };
        }
    }
}