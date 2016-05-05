using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly IAddressRepository addressRepository;


        public ContactService(IContactRepository contactRepository, IAddressRepository addressRepository)
        {
            this.contactRepository = contactRepository;
            this.addressRepository = addressRepository;

        }
        public int AddCategory(Models.DomainModels.Contact Contact)
        {

            contactRepository.Add(Contact);
            contactRepository.SaveChanges();

            return Contact.ContactID; // If Exception occurs this line will not be executed

        }

        public int UpdateCategory(Models.DomainModels.Contact Contact)
        {
            contactRepository.Update(Contact);
            contactRepository.SaveChanges();

            return Contact.ContactID;
        }

        public IEnumerable<Models.DomainModels.Contact> GetAllContacts()
        {
            return contactRepository.GetAll().ToList();

        }

        public Contact GetContactById(int id)
        {
            return contactRepository.Find(id);
        }

        public ContactResponse GetContactResponse(int? id)
        {
            ContactResponse contactResp = new ContactResponse();
            if (id != null)
            {
                contactResp.Contact = contactRepository.Find((int)id);
            }
           // contactResp.Addresses = contactRepository.GetAll();
            return contactResp;
        }
        public bool SaveContact(ContactResponse contactResp)
        {
            if (contactResp.Contact.ContactID > 0)
            {
                contactRepository.Update(contactResp.Contact);
            }
            else
            {
                contactRepository.Add(contactResp.Contact);
            }
            contactRepository.SaveChanges();

            SaveContactAddresses(contactResp);

            return true;
        }

        private void SaveContactAddresses(ContactResponse contactResp)
        {
            if (contactResp.Contact.ContactID > 0)
            {
                var addresses = addressRepository.GetAddressesById(contactResp.Contact.ContactID).ToList();

                foreach (var address in addresses)
                {
                    addressRepository.Delete(address);
                }
            }
            if (contactResp.Addresses != null && contactResp.Addresses.Any())
            {
                foreach (var address in contactResp.Addresses)
                {
                    address.ContactID = contactResp.Contact.ContactID;

                    addressRepository.Add(address);
                }
            }
            addressRepository.SaveChanges();
        }

        public ContactResponse GetAllContacts(ContactSearchRequest searchRequest)
        {
            var contacts = contactRepository.GetAllContacts(searchRequest);
            return contacts;
        }
    }
}
