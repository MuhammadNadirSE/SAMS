using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface ITicketTypeRepository : IBaseRepository<TicketType, long>
    {
        IEnumerable<TicketType> GetActiveTicketTypes();
    }
}