using System.Linq;
using TMD.Common;
using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class ContactMappers
    {
        public static Contact MapClientToServer(this ContactModel source)
        {
            return new Contact
            {

                ContactID = source.ContactID,
                FirstName = source.FirstName,
                MiddleName = source.MiddleName,
                LastName = source.LastName,
                Email = source.Email,
                CellNo=source.CellNo,
                PrimaryPhone = source.PrimaryPhone,
                HomePhone = source.HomePhone,
                Fax = source.Fax,
                ContactType = source.ContactType,
                AddressId = source.AddressId,
                CompanyName = source.CompanyName,
                CreatedBy = source.CreatedBy,
                CreatedDate = source.CreatedDate,
                UpdateDate = source.UpdateDate,
                UpdatedBy = source.UpdatedBy

            };
        }
        public static ContactModel MapServerToClient(this Contact source)
        {
            return new ContactModel
            {

                ContactID = source.ContactID,
                FirstName = source.FirstName ,
                MiddleName = source.MiddleName,
                LastName = source.LastName,
                FullName = source.FirstName+" "+source.MiddleName + " " + source.LastName,
                Email = source.Email,
                CellNo = source.CellNo,
                PrimaryPhone = source.PrimaryPhone,
                HomePhone = source.HomePhone,
                Fax = source.Fax,
                ContactType = source.ContactType,
                AddressId = source.AddressId,
                CompanyName = source.CompanyName,
                CreatedBy = source.CreatedBy,
                CreatedDate = source.CreatedDate,
                UpdateDate = source.UpdateDate,
                UpdatedBy = source.UpdatedBy

            };
        }
        public static ContactModel MapForQuotePrint(this Contact source)
        {
            var address = source.Addresses.FirstOrDefault(x => (AddressType) x.AddressType == AddressType.PrimaryAddress);
            return new ContactModel
            {
                FullName = source.FirstName + " " + source.MiddleName + " " + source.LastName,
                Email = source.Email,
                CellNo = source.CellNo,
                CompanyName = source.CompanyName,
                Address = address!=null?(address.Address1+" "+ address.City+" "+ address.Country):""
            };
        }
        public static ContactModel CreateDDL(this Contact source)
        {
            return new ContactModel
            {
                ContactID = source.ContactID,
                FirstName = source.FirstName + " " + source.LastName,
            };
        }
    }
}