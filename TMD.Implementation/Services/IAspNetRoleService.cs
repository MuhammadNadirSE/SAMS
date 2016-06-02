using System.Linq;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public interface IAspNetRoleService
    {
        string AddRole(AspNetRole role);
        string UpdateRole(AspNetRole role);
        AspNetRole GetRoleById(int id);
        IEnumberable<AspNetRole> GetAllRoles();
    }
}