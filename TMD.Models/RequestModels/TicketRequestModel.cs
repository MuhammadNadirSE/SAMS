namespace TMD.Models.RequestModels
{
    public class TicketRequestModel
    {
        public int ? TicketId { get; set; }
        public bool ViewTicketsOfAllEmployees { get; set; }
        public int EmployeeId { get; set; }
    }
}
