using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels.Product
{
    public class TechnicalSpecsViewModel
    {
        public TechnicalSpecsViewModel()
        {
            TechnicalSpecs = new List<TechnicalSpecsModel>();
        }
        public TechnicalSpecsModel TechnicalSpec { get; set; }
        public IList<TechnicalSpecsModel> TechnicalSpecs { get; set; }
    }
}