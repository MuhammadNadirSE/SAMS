using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository

    {
        public ClientRepository(IUnityContainer container) : base(container)
        {
        }

        protected override IDbSet<Client> DbSet { get { return db.Clients; } }
    }
}
