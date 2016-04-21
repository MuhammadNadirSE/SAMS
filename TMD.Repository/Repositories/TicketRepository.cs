using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.Common;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(IUnityContainer container) : base(container)
        {
        }

        protected override IDbSet<Ticket> DbSet
        {
            get { return db.Tickets; }
        }

        public List<Ticket> GetTicketsByEmployeeId(int employeeId)
        {
            return db.Tickets.Where(x => x.Employee.EmployeeId.Equals(employeeId)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>Working hours till current month according to UTC</returns>
        public double WorkingHoursOfCasualLeaves(int employeeId)
        {
            var currentDate = DateTime.UtcNow;
            return DbSet.Where(x =>
                            (x.LeaveApprovedFrom.HasValue && x.LeaveApprovedFrom.Value.Year== currentDate.Year) &&
                            //(x.LeaveApprovedFrom.HasValue && x.LeaveApprovedFrom.Value.Month == currentDate.Month) &&
                            x.EmployeeId == employeeId &&
                            x.StatusId == 1 &&
                            x.TicketType.IsLeave == true &&
                            (x.TicketType.LeaveType != null &&
                            (x.TicketType.LeaveType.Value == (int)LeaveType.Casual ||
                            x.TicketType.LeaveType.Value == (int)LeaveType.HalfDay))).ToList().Sum(x=>x.WorkingDays);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        //// <returns>Working hours till current month according to UTC</returns>
        public double WorkingHoursOfMedicalLeaves(int employeeId)
        {
            var currentDate = DateTime.UtcNow;
            return DbSet.Where(x =>
                            (x.LeaveApprovedFrom.HasValue && x.LeaveApprovedFrom.Value.Year == currentDate.Year) &&
                            //(x.LeaveApprovedFrom.HasValue && x.LeaveApprovedFrom.Value.Month == currentDate.Month) &&
                            x.EmployeeId == employeeId &&
                            x.StatusId == 1 &&
                            x.TicketType.IsLeave == true &&
                            (x.TicketType.LeaveType != null &&
                            x.TicketType.LeaveType.Value == (int)LeaveType.Medical)).ToList().Sum(x => x.WorkingDays);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>Working hours till current month according to UTC</returns>
        public double WorkingHoursOfPaidLeaves(int employeeId)
        {
            var currentDate = DateTime.UtcNow;
            return DbSet.Where(x =>
                            (x.LeaveApprovedFrom.HasValue && x.LeaveApprovedFrom.Value.Year == currentDate.Year) &&
                            //(x.LeaveApprovedFrom.HasValue && x.LeaveApprovedFrom.Value.Month == currentDate.Month) &&
                            x.EmployeeId == employeeId &&
                            x.StatusId == 1 &&
                            x.TicketType.IsLeave == true &&
                            (x.TicketType.LeaveType != null &&
                            x.TicketType.LeaveType.Value == (int)LeaveType.Annual)).ToList().Sum(x => x.WorkingDays);
        }

        public List<Ticket> GetAllExceptEmployeeId(int employeeId)
        {
            return db.Tickets.Where(x => x.EmployeeId != employeeId).ToList();
        }

        public List<Ticket> GetTicketsOfEmployeesUnderASupervisor(IEnumerable<int> employeeIds)
        {
            return db.Tickets.Where(x => employeeIds.Contains(x.EmployeeId)).ToList();
        }

    }
}
