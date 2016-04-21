using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IDistributorService
    {
        IEnumerable<Distributor> GetAll();
        Distributor FindDistributorById(int id);
        bool UpdateDistributor(Distributor distributor);
        bool SaveDistributor(Distributor distributor);
    }
}
