using System.Web.Mvc;
using TMD.Web.Controllers;
using TMD.Interfaces.IServices;
namespace IdentitySample.Controllers

{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return RedirectToAction("Home", "Admin");
            }
            
        }

        public ActionResult OneColumn()
        {
            return View();
        }
        public ActionResult TwoColumnOne()
        {
            return View();
        }
        public ActionResult TwoColumnTwo()
        {
            return View();
        }
        public ActionResult ThreeColumn()
        {
            return View();
        }
    }
}
