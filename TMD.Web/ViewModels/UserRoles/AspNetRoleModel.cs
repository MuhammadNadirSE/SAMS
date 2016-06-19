using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Web.ViewModels.UserRoles
{
    public class AspNetRoleModel
    {
        public string Id { get; set; }
        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "Role Name is required.")]
        public string Name { get; set; }
    }
}
