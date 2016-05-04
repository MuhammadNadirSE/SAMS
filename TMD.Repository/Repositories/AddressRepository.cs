using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Repository.BaseRepository;
using TMD.Models.DomainModels;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace TMD.Repository.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<Address> DbSet
        {
            get { return db.Address; }
        }

        public IEnumerable<Address> GetAddressesById(int id)
        {
            return DbSet.Where(x => x.ContactID == id);
        }
    }
}
