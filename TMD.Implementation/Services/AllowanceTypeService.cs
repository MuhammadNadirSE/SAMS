using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class AllowanceTypeService : IAllowanceTypeService
    {
        private readonly IAllowanceTypeRepository allowanceTypeRepository;
        public AllowanceTypeService(IAllowanceTypeRepository allowanceTypeRepository)
        {
            this.allowanceTypeRepository = allowanceTypeRepository;
        }

        public IEnumerable<AllowanceType> GetAllowanceTypes()
        {
            return allowanceTypeRepository.GetAll();
        }
    }
}
