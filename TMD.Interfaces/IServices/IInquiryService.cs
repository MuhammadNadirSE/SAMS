using System.Collections.Generic;
using TMD.Models.DomainModels;
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

        Inquiry GetInquiryAndInquiryDetail(int inquiryID);
        bool SaveInquiry(InquiryResponse inquiryResponse);

    }
}
