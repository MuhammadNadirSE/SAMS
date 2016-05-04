using System.Web.Mvc;
using TMD.Web.Controllers;
using TMD.Web.ViewModels.Dashboard;
namespace IdentitySample.Controllers

{
    [AllowAnonymous]
    public class DashboardController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            DashboardViewModel viewModel = new DashboardViewModel();
            
            return View(viewModel);

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
