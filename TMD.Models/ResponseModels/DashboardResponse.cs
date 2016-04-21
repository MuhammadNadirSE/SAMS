using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class DashboardResponse
    {
        public int newOrderCount { get; set; }
        public int completedOrderCount { get; set; }
        public int pendingOrderCount { get; set; }
        public int submittedOrderCount { get; set; }
    }
}
