using System.Collections.Generic;
using TMD.Models.RequestModels;

namespace Angle.ViewModels.BillDetail
{
    public class BillDetailListViewModel
    {
        public BillDetailListViewModel()
        {
            data = new List<Models.BillDetail>();
        }
        // ReSharper disable once InconsistentNaming
        public IEnumerable<Models.BillDetail> data { get; set; }
        public BillDetailSearchRequest SearchRequest { get; set; }

        /// <summary>
        /// Total Records in DB
        /// </summary>
        public int recordsTotal;

        /// <summary>
        /// Total Records Filtered
        /// </summary>
        public int recordsFiltered;
    }
}