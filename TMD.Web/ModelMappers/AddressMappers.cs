using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;
using TMD.Web.Models;


namespace TMD.Web.ModelMappers
{
    public static class AddressMappers
    {
        public static Address MapClientToServer(this AddressModel source)
        {
            return new Address
            {
                AddressId = source.AddressId,
                Country = source.Country??"",
                Address1 =source.Address1??"",
                Address2 = source.Address2??"",
                AddressType = source.AddressType,
                City = source.City??"",
                State = source.State??"",
                Street = source.Street??"",
                ContactID = source.ContactID
            };
        }
        public static AddressModel MapServerToClient(this Address source)
        {
            return new AddressModel
            {
                AddressId = source.AddressId ,
                Country = source.Country,
                Address1 = source.Address1 ,
                Address2 = source.Address2 ,
                AddressType = source.AddressType,
                City = source.City,
                State = source.State,
                Street = source.Street,
                ContactID = source.ContactID
            };
        }
    }
}