using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IAspNetUserService
    {
        AspNetUser FindById(string id);
        IEnumerable<AspNetUser> GetAllUsers();
        IEnumerable<AspNetUser> GetAllUsersOfEmployeeRole();
        bool UpdateUser(AspNetUser user);

        IEnumerable<string> GetAllUsersEmailOfSpecificRole(string roleName);
    }
}
