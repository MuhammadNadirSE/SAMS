using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TMD.Web.Models;

namespace TMD.Web.ViewModels.Case
{
    public class CaseViewModel
    
    {
        public CaseViewModel()
        {
            Order = new Models.Order();
            Case = new Models.Case();
            Charges = new List<Charge>();
        }
        public Models.Order Order { get; set; }
        public Models.Case Case { get; set; }
        public List<Models.Charge> Charges { get; set; }
        public long OrderId { get; set; }
        public long CaseId { get; set; }
    }
}