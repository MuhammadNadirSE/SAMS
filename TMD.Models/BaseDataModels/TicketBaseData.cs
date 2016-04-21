using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.BaseDataModels
{
    public class TicketBaseData
    {
        public Ticket Ticket { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Ticket> TicketsOfEmployees { get; set; }
        public IEnumerable<TicketType> TicketTypes { get; set; }
    }
}
