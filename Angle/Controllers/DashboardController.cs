using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard_v1()
        {
            return View();
        }
        public ActionResult Dashboard_v2()
        {
            return View();
        }
        public ActionResult Dashboard_v3()
        {
            return View();
        }
        public ActionResult Dashboard_h()
        {
            return View();
        }

        public ActionResult Charts()
        {
            return View();
        }
    }
}