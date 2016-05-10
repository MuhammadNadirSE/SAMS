using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IRepository
{
    public interface IContactRepository : IBaseRepository<Contact, int>
    {
        ContactResponse GetAllContacts(ContactSearchRequest contactSearchRequest);
        Contact GetContactAndAddresses(int contactId);
    }
}
