using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IInquiryDetailService
    {
        int AddInquiryDetail(InquiryDetail inquiryDetail);
        int UpdateInquiryDetail(InquiryDetail inquiryDetail);
        IEnumerable<InquiryDetail> GetInquiryDetailByInquiryId(int id);
        InquiryDetail GeInquiryById(int id);
        

    }
}
