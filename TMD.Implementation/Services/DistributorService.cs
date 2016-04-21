using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class DistributorService : IDistributorService
    {
        private readonly IDistributorRepository distributorRepository;

        public DistributorService(IDistributorRepository distributorRepository)
        {
            this.distributorRepository = distributorRepository;
        }

        public IEnumerable<Distributor> GetAll()
        {
            return distributorRepository.GetAll();
        }

        public Distributor FindDistributorById(int id)
        {
            return distributorRepository.Find(id);
        }

        public bool UpdateDistributor(Distributor distributor)
        {
            distributorRepository.Update(distributor);
            distributorRepository.SaveChanges();
            return true;
        }

        public bool SaveDistributor(Distributor distributor)
        {
            distributorRepository.Add(distributor);
            distributorRepository.SaveChanges();
            return true;
        }
    }
}
