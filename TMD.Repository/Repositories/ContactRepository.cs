using TMD.Interfaces.IRepository;
using TMD.Repository.BaseRepository;
using TMD.Models.DomainModels;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TMD.Models.Common;
using TMD.Models.Resources;

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
        private readonly Dictionary<OrderByColumnContact, Func<Contact, object>> sortClause =

           new Dictionary<OrderByColumnContact, Func<Contact, object>>
            {
                {OrderByColumnContact.EmailId, c => c.Email},
                {OrderByColumnContact.ContactName, c => c.FirstName},
                {OrderByColumnContact.CellNo, c => c.CellNo}
            };
        public ContactResponse GetAllContacts(ContactSearchRequest contactSearchRequest)
        {
            int fromRow = (contactSearchRequest.PageNo - 1) * contactSearchRequest.PageSize;
            int toRow = contactSearchRequest.PageSize;
            
            Expression<Func<Contact, bool>> query =
                s =>
                    (
                    (string.IsNullOrEmpty(contactSearchRequest.ContactName) || (s.FirstName + " " + s.LastName).Contains(contactSearchRequest.ContactName)) &&
                    (string.IsNullOrEmpty(contactSearchRequest.EmailId) || s.Email.Contains(contactSearchRequest.EmailId))&&
                    (string.IsNullOrEmpty(contactSearchRequest.CellNo) || s.CellNo.Contains(contactSearchRequest.CellNo))
                    );

            IEnumerable<Contact> contacts = contactSearchRequest.IsAsc
               ? DbSet
                   .Where(query)
                   .OrderBy(sortClause[contactSearchRequest.OrderByColumn]).Skip(fromRow)
                   .Take(toRow)
                   .ToList()
               : DbSet
                   .Where(query)
                   .OrderByDescending(sortClause[contactSearchRequest.OrderByColumn]).Skip(fromRow)
                   .Take(toRow)
                   .ToList();
            return new ContactResponse { Contacts = contacts.ToList(), TotalCount = DbSet.Count(query), FilteredCount = contacts.Count() };
        }

        public Contact GetContactAndAddresses(int contactId)
        {
            return DbSet.Include(x => x.Addresses).FirstOrDefault(x => x.ContactID.Equals(contactId));
        }
    }
}
 