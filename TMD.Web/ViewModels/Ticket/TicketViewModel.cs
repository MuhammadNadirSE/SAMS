using System.Collections.Generic;
using TMD.Web.Models;
using TMD.Web.ViewModels.Employee;

namespace TMD.Web.ViewModels.Ticket
{
    public class TicketViewModel
    {
        public TicketViewModel()
        {
            TicketTypes = new List<TicketTypeModel>();
            Tickets = new List<TicketModel>();
            Ticket = new TicketModel();
            EmployeeDdl = new List<EmployeeDDL>();
        }
        public TicketModel Ticket { get; set; }
        public List<TicketModel> Tickets { get; set; }
        public List<EmployeeDDL> EmployeeDdl { get; set; }
        public List<TicketModel> TicketsOfEmployees { get; set; }
        public List<TicketTypeModel> TicketTypes { get; set; }

        
    }
}