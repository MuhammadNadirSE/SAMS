using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IBillDetailService
    {
        BillDetail FindBillDetailById (int id);

        //IEnumerable<BillDetail> GetALlBillDetails();
        BillDetailResponse GetAllBillDetails(BillDetailSearchRequest searchRequest);
    }
}
