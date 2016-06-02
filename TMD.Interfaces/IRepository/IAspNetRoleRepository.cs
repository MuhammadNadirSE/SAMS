using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IAspNetRoleRepository : IBaseRepository<AspNetRole, string>
    {
        IEnumerable<AspNetRole> GetAllRolesExceptSuperAdmin();
    }
}
