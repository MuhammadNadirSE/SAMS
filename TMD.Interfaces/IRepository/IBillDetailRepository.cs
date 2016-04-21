using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IRepository
{
    public interface IBillDetailRepository : IBaseRepository<BillDetail, int>
    {
        BillDetailResponse GetAllBillDetails(BillDetailSearchRequest searchRequest);
    }
}
