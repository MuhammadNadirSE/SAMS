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
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Repository.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<Contact> DbSet
        {
            get { return db.Contact; }
        }

        public ContactResponse GetAllContacts(ContactSearchRequest contactSearchRequest)
        {


            return new ContactResponse();
        }
    }
}
