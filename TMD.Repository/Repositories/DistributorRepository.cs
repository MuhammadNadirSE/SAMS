using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class DistributorRepository: BaseRepository<Distributor>, IDistributorRepository
    {
        public DistributorRepository(IUnityContainer container) : base(container)
        {
        }

        protected override IDbSet<Distributor> DbSet { get { return db.Distributors; } }
    }
}
