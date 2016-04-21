using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IRepository
{
    public interface IAspNetRoleRepository : IBaseRepository<AspNetRole, long>
    {
    }
}
