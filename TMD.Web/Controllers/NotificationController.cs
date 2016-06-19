using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationService notificationService;
        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        //
        // GET: /Notification/
        public ActionResult Index()
        {
            List<NotificationModel> Notifications =
                notificationService.Get30DaysNotificationsByUserId(User.Identity.GetUserId())
                    .ToList()
                    .Select(x => x.MapServerToClient(User.Identity.GetUserId())).ToList();


            return View(Notifications);
        }

        //
        // GET: /Notification/Details/5
        public int Unread()
        {
            return notificationService.GetUnreadNotificationsCount(User.Identity.GetUserId());
        }
        [HttpPost]
        public bool Read(long id)
        {
            return notificationService.MarkNotificationAsRead(id);
        }
    }
}
