﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                FirstName = source.FirstName,
                MiddleName = source.MiddleName,
                LastName = source.LastName,
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
    }
}