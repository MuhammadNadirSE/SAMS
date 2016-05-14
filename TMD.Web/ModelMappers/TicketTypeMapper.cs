using TMD.Models.Common;
using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class TicketTypeMapper
    {
        public static TicketType MapFromClientToServer(this TicketTypeModel source)
        {
            return new TicketType
            {
                TicketTitle = source.TicketTitle,
                IsActive = source.IsActive,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedOn = source.RecCreatedOn,
                RecLastUpdateOn = source.RecLastUpdateOn,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                TicketDescription = source.TicketDescription,
                TicketTypeId = source.TicketTypeId,
                IsLeave = source.IsLeave,
                LeaveType = source.LeaveType
            };
        }
        
        public static TicketTypeModel MapFromServerToClient(this TicketType source)
        {
            
            var toReturn =  new TicketTypeModel
            {
                TicketTitle = source.TicketTitle,
                IsActive = source.IsActive,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedOn = source.RecCreatedOn,
                RecLastUpdateOn = source.RecLastUpdateOn,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                TicketDescription = source.TicketDescription,
                TicketTypeId = source.TicketTypeId,
                IsLeave = source.IsLeave,
                LeaveType = source.LeaveType
                
            };

            if (source.LeaveType != null)
            {
                var leaveTypes = (LeaveType)source.LeaveType;
                toReturn.LeaveTypes = leaveTypes;
            }
            
            return toReturn;
        }
    }
}