using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IContactService
    {
        int AddCategory(Contact contact);
        int UpdateCategory(Contact contact);
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(int id);
      //  ProductCategoryResponse GetProductCategoryResponse(int? id);
        ContactResponse GetContactResponse(int? id);
        bool SaveContact(ContactResponse contactResponse);
    }
}
