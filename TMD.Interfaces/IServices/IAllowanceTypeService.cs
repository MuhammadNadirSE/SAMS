using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IAllowanceTypeService
    {
        IEnumerable<AllowanceType> GetAllowanceTypes();
    }
}
