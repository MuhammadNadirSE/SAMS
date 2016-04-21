using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface ITicketTypeService
    {
        IEnumerable<TicketType> GetAllTicketTypes();
        /// <summary>
        /// Save Ticket Type
        /// </summary>
        /// <param name="ticketType"></param>
        /// <returns></returns>
        bool SaveTicketType(TicketType ticketType);
        /// <summary>
        /// Update Ticket Type
        /// </summary>
        /// <param name="ticketType"></param>
        /// <returns></returns>
        bool UpdateTicketType(TicketType ticketType);

        IEnumerable<TicketType> GetAllActiveTicketTypes();
        
        IEnumerable<TicketType> GetAllInActiveTicketTypes();
        TicketType GetTicketTypeById(int id);


    }
}