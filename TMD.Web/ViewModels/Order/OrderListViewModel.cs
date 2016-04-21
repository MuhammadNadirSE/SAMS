using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Web.Models;

namespace TMD.Web.ViewModels.Order
{
    public class OrderListViewModel
    {
        public OrderListViewModel()
        {
            data = new List<Models.Order>();
            Countries = new List<Country>();
        }
        public IEnumerable<Models.Order> data { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public OrderSearchRequest orderSearchRequest { get; set; }

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