using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;
using TMD.Web.Models;


namespace TMD.Web.ModelMappers
{
    public static class InquiryMapper
    {
        public static Inquiry MapClientToServer(this TMD.Web.Models.InquiryModel source)
        {
            return new Inquiry
            {
                InquiryID = source.InquiryID,
                ContactID = source.ContactID,
                CompanyName =source.CompanyName,
                UserComments = source.UserComments,
                ContactResponse = source.ContactResponse,
                CreatedDate = source.CreatedDate,
                CreatedBy = source.CreatedBy,
                UpdateDate = source.UpdateDate,
                UpdatedBy = source.UpdatedBy,
                UserId = source.UserId,
                InquiryDate = source.InquiryDate,
                Priority = source.Priority
            };
        }
        public static TMD.Web.Models.InquiryModel MapServerToClient(this Inquiry source)
        {
            return new TMD.Web.Models.InquiryModel
            {

                InquiryID = source.InquiryID,
                ContactID = source.ContactID,
                CompanyName = source.CompanyName,
                UserComments = source.UserComments,
                ContactResponse = source.ContactResponse,
                CreatedDate = source.CreatedDate,
                CreatedBy = source.CreatedBy,
                CreatedByName = source.CreatedByUser.FirstName,
                UpdateDate = source.UpdateDate,
                UpdatedBy = source.UpdatedBy,
                UserId = source.UserId,
                InquiryDate = source.InquiryDate,
                Priority = source.Priority,
                PriorityName= PriorityValue(source.Priority),
                ContactName = source.Contact.FirstName
            };
        }

        public static TMD.Web.Models.InquiryModel MapServerToClientSearch(this Inquiry source)
        {
            return new TMD.Web.Models.InquiryModel
            {

                InquiryID = source.InquiryID,
                ContactID = source.ContactID,
                CompanyName = source.CompanyName,
                UserComments = source.UserComments,
                ContactResponse = source.ContactResponse,
                CreatedDate = source.CreatedDate,
                CreatedBy = source.CreatedBy,
                CreatedByName = source.CreatedByUser.FirstName+" "+ source.CreatedByUser.LastName,
                UpdateDate = source.UpdateDate,
                UpdatedBy = source.UpdatedBy,
                UserId = source.UserId,
                InquiryDate = source.InquiryDate,
                Priority = source.Priority,
                PriorityName = PriorityValue(source.Priority),
                ContactName = source.Contact.FirstName + " " + source.Contact.LastName
            };
        }

        private static string PriorityValue(int priority)
        {
            switch (priority)
            {
                case (int)Common.Priority.Low:
                    return "Low";
                case (int)Common.Priority.Medium:
                    return "Medium";
                case (int)Common.Priority.High:
                    return "High";
                default:
                    return "";
            }
                
        }
    }
}