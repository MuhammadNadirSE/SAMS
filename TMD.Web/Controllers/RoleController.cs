using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.Common;
using TMD.Implementation.Services;
using TMD.WebBase.Mvc;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IAspNetRoleService aspNetRoleService;

        public RoleController(IAspNetRoleService aspNetRoleService)
        {
            this.aspNetRoleService = aspNetRoleService;
        }
        [SiteAuthorize(PermissionKey = "RolesList")]
        public ActionResult Index()
        {
            List<TMD.Web.ViewModels.UserRoles.AspNetRoleModel> Roles =
               aspNetRoleService.GetAllRolesExceptSuperAdmin()
                   .ToList()
                   .Select(x => x.CreateFromServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(Roles);
           
        }

        [SiteAuthorize(PermissionKey = "CreateUpdateRoles")]
        public ActionResult Create(int? id)
        {


            ViewModels.UserRoles.AspNetRoleModel exModel = new ViewModels.UserRoles.AspNetRoleModel();

            if (id != null)
            {


                var aspNetRolesModel = aspNetRoleService.GetRoleById(Convert.ToString(id));

                if (aspNetRolesModel != null)
                {
                    exModel = aspNetRolesModel.CreateFromServerToClient();
                }

            }

            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(exModel);
        }

        [SiteAuthorize(PermissionKey = "CreateUpdateRoles")]
        [HttpPost]
        public ActionResult Create(ViewModels.UserRoles.AspNetRoleModel aspNetRoleModel)
        {
            try
            {
               
                // TODO: Add insert logic here
                if (aspNetRoleModel.Id !=  null)
                {
                    aspNetRoleService.UpdateRole(aspNetRoleModel.CreateFromClientToServer());
                }
                else
                {


                    aspNetRoleService.AddRole(aspNetRoleModel.CreateFromClientToServer());
                }
                TempData["message"] = new MessageViewModel
                {
                    IsSaved = true,
                    Message = "Your data has been saved successfully!"
                };
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
