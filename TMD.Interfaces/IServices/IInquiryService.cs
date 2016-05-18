using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IInquiryService
    {
        int AddInquiry(Inquiry inquiry);
        int UpdateInquiry(Inquiry inquiry);
        IEnumerable<Inquiry> GetAllInquiries();
        Inquiry GeInquiryById(int id);
        InquiryResponse GetInquiryResponse(int? id);

        Inquiry GetInquiryAndInquiryDetail(int inquiryId);
        bool SaveInquiry(InquiryResponse inquiryResponse);

        InquiryResponse GetAllInquiries(InquirySearchRequest searchRequest);
    }
}
