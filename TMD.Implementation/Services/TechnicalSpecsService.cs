

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
    public class TechnicalSpecsService : ITechnicalSpecsService
    {
        private readonly ITechnicalSpecsRepository technicalSpecsRepository;

        public TechnicalSpecsService(ITechnicalSpecsRepository technicalSpecsRepository)
        {
            this.technicalSpecsRepository = technicalSpecsRepository;
        }


        public int AddTechnicalSpecs(TechnicalSpec technicalSpec)
        {
           technicalSpecsRepository.Add(technicalSpec);
            technicalSpecsRepository.SaveChanges();

            return technicalSpec.TechnicalSpecId;
        }

        public int UpdateTechnicalSpecs(TechnicalSpec technicalSpec)
        {
            technicalSpecsRepository.Update(technicalSpec);
            technicalSpecsRepository.SaveChanges();

            return technicalSpec.TechnicalSpecId;
        }

        public IEnumerable<TechnicalSpec> GetAllTechnicalSpecs()
        {
            return technicalSpecsRepository.GetAll().ToList();
        }

        public TechnicalSpec GetPTechnicalSpecsById(int id)
        {
            return technicalSpecsRepository.Find(id);
        }
    }
}
