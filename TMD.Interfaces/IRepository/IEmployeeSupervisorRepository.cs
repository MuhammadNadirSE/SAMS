using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IRepository
{
    public interface IEmployeeSupervisorRepository : IBaseRepository<EmployeeSupervisor, long>
    {
        IEnumerable<EmployeeSupervisor> GetSupervisorsByEmployeeId(int id);
    }
}
