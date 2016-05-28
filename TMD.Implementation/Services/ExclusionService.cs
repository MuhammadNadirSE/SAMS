

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class ExclusionService : IExclusionService
    {
        private readonly IExclusionRepository exclusionRepository;

        public ExclusionService(IExclusionRepository exclusionRepository)
        {
            this.exclusionRepository = exclusionRepository;
        }


        public int AddExclusion(Exclusion exclusion)
        {
            exclusionRepository.Add(exclusion);
            exclusionRepository.SaveChanges();

            return exclusion.ExclusionId;
        }

        public int UpdateExclusion(Exclusion exclusion)
        {
            exclusionRepository.Update(exclusion);
            exclusionRepository.SaveChanges();

            return exclusion.ExclusionId;
        }

        public IEnumerable<Exclusion> GetAllExclusions()
        {
            return exclusionRepository.GetAll().ToList();
        }

        public Exclusion GetExclusionById(int id)
        {
            return exclusionRepository.Find(id);
        }
    }
}
