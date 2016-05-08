using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using TMD.Implementation.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.Common;
using TMD.Models.DomainModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TMD.Models.MenuModels;
using TMD.WebBase.UnityConfiguration;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        #region Private
        
        private IMenuRightsService menuRightService;

        #endregion

        #region Protected
        // GET: Base
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            menuRightService = UnityWebActivator.Container.Resolve<IMenuRightsService>();

            if (Session["UserID"] == null || Session["UserID"].ToString() == string.Empty)
                SetUserDetail();
           // SetCultureInfo();
        }
       
        #endregion
        
        #region Public

        //when isForce =  true it sets the value, no matter session has or not
        public void SetUserDetail()
        {
            Session["FullName"] = Session["UserID"] = string.Empty;

            if (!User.Identity.IsAuthenticated) return;
            AspNetUser result =
                HttpContext.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(User.Identity.GetUserId());
            string role =
                HttpContext.GetOwinContext()
                    .Get<ApplicationRoleManager>()
                    .FindById(result.AspNetRoles.ToList()[0].Id)
                    .Name;
            
            Session["FirstName"] = result.FirstName;
            Session["LastName"] = result.LastName;
            Session["EmployeeEmail"] = result.Email;
            Session["UserID"] = result.Id;
            if (result.Employees.Any())
            {
                Session["FullName"] = result.Employees.FirstOrDefault().FullName;
                Session["EmployeeID"] = result.Employees.FirstOrDefault().EmployeeId;
            }
            else
            {
                Session["FullName"] = result.FirstName;
            }
            Session["RoleName"] = role;

            //Load Menu and Set Permissions
            IList<MenuRight> menuItems = menuRightService.FindMenuItemsByRoleId(result.AspNetRoles.ToList()[0].Id).ToList();
            //Save menu in sessions
            Session["MenuItemsSet"] = menuItems;
            //save menu permissions in session
            Session["UserPermissionSet"] = menuItems.Select(user => user.Menu.PermissionKey).ToArray();
        }

        #endregion

        [HttpPost]
        public JsonResult SetGMTSession(string GMT)
        {
            Session["ClientGMT"] = GMT;
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public void SetCultureInfo()
        {
            CultureInfo info;
            if (Session["Culture"] != null)
            {
                info = new CultureInfo(Session["Culture"].ToString());
            }
            else
            {
                info = new CultureInfo("en");
                Session["Culture"] = info.Name;
            }
            info.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = info;
            System.Threading.Thread.CurrentThread.CurrentUICulture = info;
        } 
    }
}