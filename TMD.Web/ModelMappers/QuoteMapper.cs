using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class QuoteMapper
    {
        public static Quote MapClientToServer(this QuoteModel source)
        {
            return new Quote
            {
                QuoteID=source.QuoteID,
                ContactId=source.ContactId,
                InquiryId=source.InquiryId,
                QuoteReferenceNo=source.QuoteReferenceNo,
                Subject=source.Subject,
                DeliveryTerms=source.DeliveryTerms,
                FreeServiceTerms=source.FreeServiceTerms,
                InstallationTerms=source.InstallationTerms,
                ValidityTerms=source.ValidityTerms,
                WarrantyTerms=source.WarrantyTerms,
                PaymentTerms=source.PaymentTerms,
                
                CreatedBy = source.CreatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedBy = source.UpdatedBy,
                UpdatedDate = source.UpdatedDate  

            };
        }
        public static QuoteModel MapServerToClient(this Quote source)
        {
            return new QuoteModel
            {
                QuoteID = source.QuoteID,
                ContactId = source.ContactId,
                InquiryId = source.InquiryId,
                QuoteReferenceNo = source.QuoteReferenceNo,
                Subject = source.Subject,
                DeliveryTerms = source.DeliveryTerms,
                FreeServiceTerms = source.FreeServiceTerms,
                InstallationTerms = source.InstallationTerms,
                ValidityTerms = source.ValidityTerms,
                WarrantyTerms = source.WarrantyTerms,
                PaymentTerms = source.PaymentTerms,

                CreatedBy = source.CreatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedBy = source.UpdatedBy,
                UpdatedDate = source.UpdatedDate

            };
        }

        public static QuoteDetailModel MapServerToClient(this QuoteDetail source)
        {
            return new QuoteDetailModel
            {
                QuoteDetailId=source.QuoteDetailId,
                QuoteId=source.QuoteId,
                ProductId=source.ProductId,
                ModelId=source.ModelId,
                Make=source.Make,
                Price=source.Price,
                Quantity=source.Quantity,
                Discount=source.Discount
            };
        }
        public static QuoteDetail MapClientToServer(this QuoteDetailModel source)
        {
            return new QuoteDetail
            {
                QuoteDetailId = source.QuoteDetailId,
                QuoteId = source.QuoteId,
                ProductId = source.ProductId,
                ModelId = source.ModelId,
                Make = source.Make,
                Price = source.Price,
                Quantity = source.Quantity,
                Discount = source.Discount
            };
        }
    }
}