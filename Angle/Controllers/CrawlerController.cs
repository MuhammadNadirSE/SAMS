using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Angle.Models;

namespace Angle.Controllers
{
    public class CrawlerController : Controller
    {
        public ActionResult Crawl()
        {

            const string url = "http://yassershaikh.com/wp-login.php";
            const string userName = "guest";
            const string pwd = ".netrocks!!"; // n this not my real pwd :P  
            const string profileUrl = "http://yassershaikh.com/wp-admin/profile.php";

           Crawler.Login1();
            return null;
        }
    }
}