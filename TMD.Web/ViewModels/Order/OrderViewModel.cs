using System.Collections.Generic;
using iTextSharp.text;
using TMD.Models.DomainModels;

namespace TMD.Web.ViewModels.Order
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Order = new Models.Order();
        }
        public Models.Order Order { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<County> Counties { get; set; }
        public IEnumerable<OrderStatus> OrderStatuses { get; set; }
    }
}