using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class BillDetailService : IBillDetailService
    {
        private readonly IBillDetailRepository billDetailRepository;

        public BillDetailService(IBillDetailRepository billDetailRepository)
        {
            this.billDetailRepository = billDetailRepository;
        }

        public BillDetail FindBillDetailById(int id)
        {
            return billDetailRepository.Find(id);
        }

        public BillDetailResponse GetAllBillDetails(BillDetailSearchRequest searchRequest)
        {
            return billDetailRepository.GetAllBillDetails(searchRequest);
        }
    }
}
