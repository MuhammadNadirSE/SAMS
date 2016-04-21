using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels.Common;
using TMD.WebBase.Mvc;
using TMD.Models.Common;

namespace TMD.Web.Controllers
{
    public class TicketTypeController : BaseController
    {
        //
        // GET: /TicketType/
        private readonly ITicketTypeService ticketTypeService;

        public TicketTypeController(ITicketTypeService ticketTypeService)
        {
            this.ticketTypeService = ticketTypeService;
        }

        [SiteAuthorize(PermissionKey = "TicketTypeIndex")]
        public ActionResult Index()
        {
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            var ticketTypeModel = ticketTypeService.GetAllTicketTypes().Select(x => x.MapFromServerToClient()).ToList();
            return View(ticketTypeModel);
        }

        [SiteAuthorize(PermissionKey = "TicketTypeView")]
        public ActionResult Create(int ? id)
        {
            var model = new TicketTypeModel {IsActive = true};
            if (id != null)
            {
                model = ticketTypeService.GetTicketTypeById((int)id).MapFromServerToClient();
            }
            return View(model);
        }

        [SiteAuthorize(PermissionKey = "TicketTypeCreate")]
        [HttpPost]
        public ActionResult Create(TicketTypeModel ticketTypeModel)
        {

            if (ticketTypeModel.TicketTypeId == 0)
            {
                ticketTypeModel.RecCreatedBy = User.Identity.GetUserId();
                ticketTypeModel.RecCreatedOn = DateTime.UtcNow;
                TempData["Message"] = new MessageViewModel { IsSaved = true, Message = "Ticket Type has been saved successfully." };
            }
            else
            {
                TempData["Message"] = new MessageViewModel { IsUpdated = true, Message = "Ticket Type has been updated." };
            }

            ticketTypeModel.RecLastUpdatedBy = User.Identity.GetUserId();
            ticketTypeModel.RecLastUpdateOn = DateTime.UtcNow;

            if (ticketTypeModel.IsLeave)
            {
                if (ticketTypeModel.LeaveTypes != null)
                {
                    var leaveType = (LeaveType)ticketTypeModel.LeaveTypes;
                    switch (leaveType)
                    {
                        case LeaveType.Casual:
                            ticketTypeModel.LeaveType = 0;
                            break;
                        case LeaveType.Medical:
                            ticketTypeModel.LeaveType = 1;
                            break;
                        case LeaveType.HalfDay:
                            ticketTypeModel.LeaveType = 2;
                            break;
                        case LeaveType.Annual:
                            ticketTypeModel.LeaveType = 3;
                            break;
                    }
                }
            }

            ticketTypeService.SaveTicketType(ticketTypeModel.MapFromClientToServer());
            

            return RedirectToAction("Index");
        }
	}

}