using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IAspNetUserRepository : IBaseRepository<AspNetUser, string>
    {
        IEnumerable<AspNetUser> GetAllUsers();
        IEnumerable<AspNetUser> GetAllUsersOfEmployeeRole();
        IEnumerable<string> GetAllUsersEmailOfSpecificRole(string roleName);
    }
}
