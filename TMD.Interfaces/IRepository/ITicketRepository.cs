using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface ITicketRepository:IBaseRepository<Ticket,long>
    {
        List<Ticket> GetTicketsByEmployeeId(int employeeId);
        double WorkingHoursOfCasualLeaves(int employeeId);
        double WorkingHoursOfMedicalLeaves(int employeeId);
        double WorkingHoursOfPaidLeaves(int employeeId);
        List<Ticket> GetAllExceptEmployeeId(int employeeId);
        List<Ticket> GetTicketsOfEmployeesUnderASupervisor(IEnumerable<int> emploeeIds);
    }
}