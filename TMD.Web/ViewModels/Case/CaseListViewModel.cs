using System.Collections.Generic;

namespace TMD.Web.ViewModels.Case
{
    public class CaseListViewModel
    {
        public CaseListViewModel()
        {
            Cases = new List<Models.Case>();
            Order = new Models.Order();
        }
        public List<Models.Case> Cases { get; set; }
        public Models.Order Order { get; set; }
        public long OrderId { get; set; }
    }
}