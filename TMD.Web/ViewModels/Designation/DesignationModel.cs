using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Web.ViewModels.Designation
{
    public class DesignationModel
    {
        public int DesignationId { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDt { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDt { get; set; }
    }
}
