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
    public class NotificationController : BaseController
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
                notificationService.GetAllNotificationsByUserId(User.Identity.GetUserId())
                    .ToList()
                    .Select(x => x.MapServerToClient()).ToList();


            return View(Notifications);
        }

        //
        // GET: /Notification/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Notification/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Notification/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Notification/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Notification/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Notification/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Notification/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
