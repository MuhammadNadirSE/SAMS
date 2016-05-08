using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TMD.Implementation.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.MenuModels;
using TMD.Web.ViewModels.Common;
using TMD.Web.ViewModels.RightsManagement;
using TMD.WebBase.Mvc;

namespace TMD.Web.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class RolesController : Controller
    {
        private IMenuRightsService menuRightsService;

        public RolesController(IMenuRightsService menuRightsService)
        {
            this.menuRightsService = menuRightsService;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        //[SiteAuthorize(PermissionKey = "RightsManagement")]
        public ActionResult RightsManagement()
        {
            UserMenuResponse userMenuRights = menuRightsService.GetRoleMenuRights(string.Empty);
            RightsManagementViewModel viewModel = new RightsManagementViewModel();

            viewModel.Roles = userMenuRights.Roles.ToList();
            viewModel.Rights =
                userMenuRights.Menus.Select(
                    m =>
                        new Rights
                        {
                            MenuId = m.MenuId,
                            MenuTitle = m.MenuTitle,
                            IsParent = m.IsRootItem,
                            IsSelected = userMenuRights.MenuRights.Any(menu => menu.Menu.MenuId == m.MenuId),
                            ParentId = m.ParentItem != null ? m.ParentItem.MenuId : (int?)null
                        }).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(viewModel);
        }

        public ActionResult PostRightsManagement(string roleValue, string selectedList)
        {
            UserMenuResponse userMenuRights = menuRightsService.SaveRoleMenuRight(roleValue, selectedList, RoleManager.FindById(roleValue));
            RightsManagementViewModel viewModel = new RightsManagementViewModel();
            viewModel.Roles = userMenuRights.Roles.ToList();
            viewModel.Rights =
                userMenuRights.Menus.Select(
                    m =>
                        new Rights
                        {
                            MenuId = m.MenuId,
                            MenuTitle = m.MenuTitle,
                            IsParent = m.IsRootItem,
                            IsSelected = userMenuRights.MenuRights.Any(menu => menu.Menu.MenuId == m.MenuId),
                            ParentId = m.ParentItem != null ? m.ParentItem.MenuId : (int?)null
                        }).ToList();
            viewModel.SelectedRoleId = roleValue;
            TempData["message"] = new MessageViewModel
            {
                Message = "Record has been updated.",
                IsUpdated = true
           };
            return RedirectToAction("RightsManagement");
        }
        [HttpPost]
        public ActionResult RightsManagement(FormCollection collection)
        {
            string RoleId = collection.Get("SelectedRoleId");
            UserMenuResponse userMenuRights = menuRightsService.GetRoleMenuRights(RoleId);
            RightsManagementViewModel viewModel = new RightsManagementViewModel();

            viewModel.Roles = userMenuRights.Roles.ToList();
            viewModel.Rights =
                userMenuRights.Menus.Select(
                    m =>
                        new Rights
                        {
                            MenuId = m.MenuId,
                            MenuTitle = m.MenuTitle,
                            IsParent = m.IsRootItem,
                            IsSelected = userMenuRights.MenuRights.Any(menu => menu.Menu.MenuId == m.MenuId),
                            ParentId = m.ParentItem != null ? m.ParentItem.MenuId : (int?)null,

                        }).ToList();
            viewModel.SelectedRoleId = RoleId;
            return View(viewModel);
        }
    }
}
