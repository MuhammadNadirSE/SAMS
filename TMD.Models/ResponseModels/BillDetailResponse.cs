using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class BillDetailResponse
    {
        public BillDetailResponse()
        {
            BillDetails = new List<BillDetail>();
        }
        public IEnumerable<BillDetail> BillDetails { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public int FilteredCount { get; set; }
    }
}
