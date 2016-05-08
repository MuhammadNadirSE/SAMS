using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TMD.Implementation.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.MenuModels;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class MenuController : Controller
    {
        #region Private

        private readonly IMenuRightsService menuRightService;

        /// <summary>
        /// User Manger for logged in user credientals
        /// </summary>
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        #region Constructor
        public MenuController(IMenuRightsService menuRightService)
        {
            this.menuRightService = menuRightService;
        }
        #endregion

        /// <summary>
        /// Load Menu items with respect to roles
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult LoadMenu()
        {
            MenuViewModel menuVM = new MenuViewModel();
            if (Session["UserPermissionSet"] != null)
            {
                IList<MenuRight> menuItems = (List<MenuRight>)Session["MenuItemsSet"];
                menuVM = new MenuViewModel
                {
                    MenuRights = menuItems,
                    MenuHeaders = menuItems.Where(x => x.Menu.IsRootItem)
                };
            }
            else
            {
                string userName = HttpContext.User.Identity.Name;
                if (!String.IsNullOrEmpty(userName))
                {
                    AspNetUser userResult = UserManager.FindByName(userName);
                    if (userResult != null)
                    {
                        IList<AspNetRole> roles = userResult.AspNetRoles.ToList();
                        if (roles.Count > 0)
                        {
                            IList<MenuRight> menuItems = menuRightService.FindMenuItemsByRoleId(roles[0].Id).ToList();
                            
                            //Save menu in sessions
                            Session["MenuItemsSet"] = menuItems;
                            //save menu permissions in session
                            Session["UserPermissionSet"] = menuItems.Select(user => user.Menu.PermissionKey).ToArray();

                            menuVM = new MenuViewModel
                            {
                                MenuRights = menuItems,
                                MenuHeaders = menuItems.Where(x => x.Menu.IsRootItem)
                            };
                        }
                    }
                }
            }
            
            return View(menuVM);
        }
    }
}