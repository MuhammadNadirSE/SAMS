using System;
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
using TMD.WebBase.UnityConfiguration;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        #region Private

        //private ApplicationUserManager _userManager;
        private IAttendanceService attendanceService;

        #endregion

        #region Protected
        // GET: Base
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            attendanceService = UnityWebActivator.Container.Resolve<IAttendanceService>();

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
            Session["FullName"] = result.Employees.FirstOrDefault().FullName;
            Session["EmployeeID"] = result.Employees.FirstOrDefault().EmployeeId;
            Session["RoleName"] = role;


            //var userAttendance = attendanceService.GetAttendanceByEmployeeIdInCurrentDate((int)Session["EmployeeID"]);
            //if (userAttendance == null)
            //{
            //    Session["UserAttendanceStatus"] = EmployeeAttendanceStatus.CheckedOut;
            //}
            //else
            //{
            //    Session["UserAttendanceStatus"] = (EmployeeAttendanceStatus)userAttendance.Status;
            //}
            

            //AspNetUser userResult = UserManager.FindById(User.Identity.GetUserId());
            //List<AspNetRole> roles = userResult.AspNetRoles.ToList();
        }
        //public ApplicationUserManager UserManager
        //{
        //    get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        //    private set { _userManager = value; }
        //}

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