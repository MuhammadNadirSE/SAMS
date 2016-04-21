using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.MenuModels;

namespace TMD.Web.ViewModels.RightsManagement
{
    public class RightsManagementViewModel
    {
        public List<Rights> Rights { get; set; }
        public string SelectedRoleId { get; set; }

        public List<AspNetRole> Roles { get; set; }
    }
}