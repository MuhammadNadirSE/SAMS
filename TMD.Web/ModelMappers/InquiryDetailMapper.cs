using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;
using TMD.Web.Models;


namespace TMD.Web.ModelMappers
{
    public static class InquiryDetailMapper
    {
        public static InquiryDetail MapClientToServer(this TMD.Web.Models.InquiryDetailModel source)
        {
            return new InquiryDetail
            {
                InquiryID = source.InquiryID,
                InquiryDetailID = source.InquiryDetailID,
                ProductID = source.ProductID
        



            };
        }
        public static TMD.Web.Models.InquiryDetailModel MapServerToClient(this InquiryDetail source)
        {
            return new TMD.Web.Models.InquiryDetailModel
            {

                InquiryID = source.InquiryID,
                InquiryDetailID = source.InquiryDetailID,
                ProductID = source.ProductID
          

            };
        }
    }
}