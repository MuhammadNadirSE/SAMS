using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.Common;
using TMD.Web.ViewModels.Product;
using TMD.WebBase.Mvc;
using TMD.Web.Models;
using TMD.Implementation.Services;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class AspNetRoleController : Controller
    {
        private readonly IAspNetRoleService aspNetRoleService;

        public AspNetRoleController(IAspNetRoleService aspNetRoleService)
        {
            this.aspNetRoleService = aspNetRoleService;
        }
        // [SiteAuthorize(PermissionKey = "ExclusionsList")]
        public ActionResult Index()
        {
            List<TMD.Web.ViewModels.UserRoles.AspNetRoleModel> Roles =
               aspNetRoleService.GetAllRoles()
                   .ToList()
                   .Select(x => x.CreateFromServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(Roles);
           
        }

        // [SiteAuthorize(PermissionKey = "CreateUpdateTechSpec")]
        public ActionResult Create(int? id)
        {


            ViewModels.UserRoles.AspNetRoleModel exModel = new ViewModels.UserRoles.AspNetRoleModel();

            if (id != null)
            {


                var aspNetRolesModel = aspNetRoleService.GetRoleById(Convert.ToInt32(id));

                if (aspNetRolesModel != null)
                {
                    exModel = aspNetRolesModel.CreateFromServerToClient();
                }

            }

            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(exModel);
        }

        //  [SiteAuthorize(PermissionKey = "CreateUpdateTechSpec")]
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
