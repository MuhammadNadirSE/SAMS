using System.Linq;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public interface IAspNetRoleService
    {
        IEnumberable<AspNetRole> GetAllRoles();
    }
}