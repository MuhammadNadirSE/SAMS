using System;
using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.BaseDataModels;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;
        private readonly ITicketTypeRepository ticketTypeRepository;
        private readonly IEmployeeRepository employeeRepository;

        public TicketService(ITicketRepository ticketRepository, ITicketTypeRepository ticketTypeRepository, IEmployeeRepository employeeRepository)
        {
            this.ticketRepository = ticketRepository;
            this.ticketTypeRepository = ticketTypeRepository;
            this.employeeRepository = employeeRepository;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return ticketRepository.GetAll();
        }

        public bool SaveTicket(Ticket ticketType)
        {
            if(ticketType.TicketId > 0)
                ticketRepository.Update(ticketType);
            else
                ticketRepository.Add(ticketType);
            
            ticketRepository.SaveChanges();
            return true;
        }

        public bool UpdateTicket(Ticket ticketType)
        {
            ticketRepository.Update(ticketType);
            ticketRepository.SaveChanges();
            return true;
        }

        public Ticket GetTicketById(int id)
        {
            return ticketRepository.Find(id);
        }

        public bool ReplyTicket(TicketReplyResponse ticketReplyResponse)
        {
            Ticket ticket =  ticketRepository.Find(ticketReplyResponse.TicketId);
            if (ticket != null)
            {
                ticket.TicketReply = ticketReplyResponse.TicketReply;
                ticket.RecLastUpdateOn = DateTime.UtcNow;
                ticket.RecLastUpdatedBy = ticketReplyResponse.TicketRepliedBy;
                ticket.StatusId = ticketReplyResponse.Status;

                ticket.LeaveApprovedBy = ticketReplyResponse.LeaveApprovedBy;
                ticket.LeaveApprovedDate = ticketReplyResponse.LeaveApprovedDate;
                ticket.LeaveApprovedFrom = ticketReplyResponse.LeaveApprovedFrom;
                ticket.LeaveApprovedTo = ticketReplyResponse.LeaveApprovedTo;
                ticket.WorkingDays = ticketReplyResponse.WorkingDays;

                ticketRepository.SaveChanges();
                return true;
            }
            return false;
        }


        public TicketBaseData GetTicketData(TicketRequestModel ticketRequestModel)
        {
            var ticketBaseData = new TicketBaseData();
            if (ticketRequestModel.TicketId != null)
                ticketBaseData.Ticket = ticketRepository.Find((int) ticketRequestModel.TicketId);

            ticketBaseData.TicketTypes = ticketTypeRepository.GetActiveTicketTypes();
            ticketBaseData.Tickets = ticketRepository.GetTicketsByEmployeeId(ticketRequestModel.EmployeeId);
            ticketBaseData.Employees = employeeRepository.GetAll();
          

            if (!ticketRequestModel.ViewTicketsOfAllEmployees)
            {
                var employee = employeeRepository.Find(ticketRequestModel.EmployeeId);

                var emploeeIds = employee.SupervisorOfEmployees.Select(x => x.EmployeeId).ToList();

                var ticketsOfEmployees = ticketRepository.GetTicketsOfEmployeesUnderASupervisor(emploeeIds);

                ticketBaseData.TicketsOfEmployees = ticketsOfEmployees;
            }
            else
            {
                var ticketsOfEmployees = ticketRepository.GetAllExceptEmployeeId(ticketRequestModel.EmployeeId);

                ticketBaseData.TicketsOfEmployees = ticketsOfEmployees;
            }
            

            return ticketBaseData;
        }

        
    }
}
