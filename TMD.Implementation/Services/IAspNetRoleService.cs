using System.Collections.Generic;
using System.Linq;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public interface IAspNetRoleService
    {
        string AddRole(AspNetRole role);
        string UpdateRole(AspNetRole role);
        string GetLatestAvailableRoleId();
        AspNetRole GetRoleById(string id);
        IEnumerable<AspNetRole> GetAllRolesExceptSuperAdmin();
    }
}