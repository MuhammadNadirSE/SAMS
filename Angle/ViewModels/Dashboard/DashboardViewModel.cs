using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMD.Web.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public IEnumerable<Models.Order> CompletedOrders { get; set; }
        public IEnumerable<Models.Order> NewOrders { get; set; }
        public int newOrderCount { get; set; }
        public int completedOrderCount { get; set; }
        public int pendingOrderCount { get; set; }
        public int submittedOrderCount { get; set; }
    }
}