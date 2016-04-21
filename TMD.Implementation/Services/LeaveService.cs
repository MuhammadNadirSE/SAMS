using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    class LeaveService:ILeaveService
    {
        private readonly ILeaveRepository leaveRepository;

        public LeaveService(ILeaveRepository leaveRepository)
        {
            this.leaveRepository = leaveRepository;
        }

        public bool SaveLeave(Leave leave)
        {
            if(leave.LeaveId > 0)
                leaveRepository.Update(leave);
            else
                leaveRepository.Add(leave);
            return true;
        }

        public IEnumerable<Leave> GetaAlLeaves()
        {
            return leaveRepository.GetAll();
        }
    }
}
