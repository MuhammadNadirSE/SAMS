using System.Collections.Generic;
using TMD.Models.BaseDataModels;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAllTickets();
        bool SaveTicket(Ticket ticketType);
        /// <summary>
        /// Update Ticket
        /// </summary>
        /// <param name="ticketType"></param>
        /// <returns>True if ticket saved.</returns>
        bool UpdateTicket(Ticket ticketType);

        Ticket GetTicketById(int id);

        bool ReplyTicket(TicketReplyResponse ticketReplyResponse );
        TicketBaseData GetTicketData(TicketRequestModel ticketRequestModel);

    }
}