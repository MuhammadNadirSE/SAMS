using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
     public interface IAspNetRoleService
    {
        string AddRole(AspNetRole role);
        string UpdateRole(AspNetRole role);
        string GetLatestAvailableRoleId();
        AspNetRole GetRoleById(string id);
        IEnumerable<AspNetRole> GetAllRolesExceptSuperAdmin();
        IEnumerable<AspNetRole> GetAllRoles();
    }
}
