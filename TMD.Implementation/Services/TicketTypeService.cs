using System;
using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    class TicketTypeService : ITicketTypeService
    {
        private readonly ITicketTypeRepository ticketTypeRepository;

        public TicketTypeService(ITicketTypeRepository ticketTypeRepository)
        {
            this.ticketTypeRepository = ticketTypeRepository;
        }
        public IEnumerable<TicketType> GetAllTicketTypes()
        {
            return ticketTypeRepository.GetAll();
        }

        public bool SaveTicketType(TicketType ticketType)
        {
            if(ticketType.TicketTypeId > 0)
                ticketTypeRepository.Update(ticketType);
            else
                ticketTypeRepository.Add(ticketType);

            ticketTypeRepository.SaveChanges();
            return true;

        }

        public bool UpdateTicketType(TicketType ticketType)
        {
            ticketTypeRepository.Update(ticketType);
            ticketTypeRepository.SaveChanges();
            return true;
        }

        public IEnumerable<TicketType> GetAllActiveTicketTypes()
        {
            return ticketTypeRepository.GetAll().Where(x => x.IsActive.Equals(true));
        }

        public IEnumerable<TicketType> GetAllInActiveTicketTypes()
        {
            return ticketTypeRepository.GetAll().Where(x => x.IsActive.Equals(false));
        }

        public TicketType GetTicketTypeById(int id)
        {
            return ticketTypeRepository.Find(id);
        }

    }
}
