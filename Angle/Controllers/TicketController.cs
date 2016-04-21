using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Angle.Controllers;
using Angle.ViewModels.Common;
using iTextSharp.text.pdf.qrcode;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TMD.Implementation.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels.Common;
using TMD.Web.ViewModels.Ticket;
using TMD.WebBase.Mvc;
using WebGrease.Css.Extensions;

namespace TMD.Web.Controllers
{
    public class TicketController : BaseController
    {
        //
        // GET: /Ticket/
        private readonly ITicketService ticketService;
        private readonly IEmployeeService employeeService;
        private readonly IAspNetUserService aspNetUserService;
        private readonly ITicketTypeService ticketTypeService;

        private ApplicationUserManager _userManager;
        private DateTime currentTime = DateTime.UtcNow;
        //private readonly int = 
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public TicketController(ITicketService ticketService,IEmployeeService employeeService, IAspNetUserService aspNetUserService, ITicketTypeService ticketTypeService)
        {
            this.ticketService = ticketService;
            this.employeeService = employeeService;
            this.aspNetUserService = aspNetUserService;
            this.ticketTypeService = ticketTypeService;
        }

        [SiteAuthorize(PermissionKey = "TicketIndex")]
        public ActionResult Index()
        {
            var ticketViewModel = new TicketViewModel();
            var ticketRequest = new TicketRequestModel
            {
                EmployeeId = (int) Session["EmployeeID"]
            };

            var userPermissionsSet = (string[])System.Web.HttpContext.Current.Session["UserPermissionSet"];
            if (userPermissionsSet.Contains("ViewAllTickets"))
            {
                ticketRequest.ViewTicketsOfAllEmployees = true;
            }

            var baseData = ticketService.GetTicketData(ticketRequest);
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            if (baseData.TicketsOfEmployees != null)
            {
                ticketViewModel.TicketsOfEmployees = baseData.TicketsOfEmployees.Select(x => x.MapFromServerToClient(GMT)).OrderByDescending(x=>x.RecCreatedOn).ToList();
            }

            
            ticketViewModel.Tickets = baseData.Tickets.Select(x => x.MapFromServerToClient(GMT)).OrderByDescending(x=>x.RecCreatedOn).ToList();
            ticketViewModel.TicketTypes = baseData.TicketTypes.Select(x => x.MapFromServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;

            return View(ticketViewModel);
        }

        [SiteAuthorize(PermissionKey = "ViewTicket")]
        public ActionResult Create(int ? id)
        {
            var model = new TicketViewModel();
            var ticketRequest = new TicketRequestModel
            {
                TicketId = id, 
                EmployeeId = (int) Session["EmployeeID"]
            };
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            var baseData = ticketService.GetTicketData(ticketRequest);
            if (baseData.Ticket != null)
                model.Ticket = baseData.Ticket.MapFromServerToClient(GMT);
            

            model.Tickets = baseData.Tickets.Select(x => x.MapFromServerToClient(GMT)).ToList();
            model.TicketTypes = baseData.TicketTypes.Select(x => x.MapFromServerToClient()).OrderBy(x=>x.TicketTitle).ToList();
            model.EmployeeDdl = baseData.Employees.Select(x => x.MapEmployeeDdlFromServerToClient()).OrderBy(x=>x.FullName).ToList();

            return View(model);
        }

        [SiteAuthorize(PermissionKey = "ReplyTicket")]
        public JsonResult ReplyTicket(TicketReplyViewModel ticketReplyViewModel)
        {
            if (ticketReplyViewModel.LeaveApprovedFrom != null && ticketReplyViewModel.LeaveApprovedTo != null)
            {
                ticketReplyViewModel.LeaveApprovedBy = (int) Session["EmployeeID"];
                ticketReplyViewModel.LeaveApprovedDate = DateTime.UtcNow;
            }
            ticketReplyViewModel.TicketRepliedBy = User.Identity.GetUserId();
            TicketReplyResponse ticketReplyResponse = ticketReplyViewModel.MapReplyFromClientToServer();
            bool replyConfirmation = ticketService.ReplyTicket(ticketReplyResponse);
            ticketReplyViewModel.replyConfirmationStatus = replyConfirmation;
      
            return Json(ticketReplyViewModel, JsonRequestBehavior.AllowGet);
        }

        [SiteAuthorize(PermissionKey = "GenerateTicket")]
        [HttpPost]
        public ActionResult Create(TicketViewModel model)
        {
            string[] userPermissionsSet = (string[])System.Web.HttpContext.Current.Session["UserPermissionSet"];
            if (model.Ticket.TicketId == 0)
            {
                model.Ticket.RecCreatedBy = User.Identity.GetUserId();
                model.Ticket.RecCreatedOn = DateTime.UtcNow;
                TempData["Message"] = new MessageViewModel { IsSaved = true, Message = "Ticket has been saved successfully." };
            }
            else
                TempData["Message"] = new MessageViewModel { IsUpdated = true, Message = "Ticket has been updated successfully." };

            if (userPermissionsSet.Contains("GenerateEmployeeTicket"))
            {
                model.Ticket.EmployeeId = model.Ticket.EmployeeId;
                model.Ticket.StatusId = Convert.ToInt32(Session["EmployeeId"].ToString()) == model.Ticket.EmployeeId ? 0 : 1;
                model.Ticket.LeaveApprovedBy = Convert.ToInt32(Session["EmployeeId"].ToString());
                model.Ticket.LeaveApprovedFrom = model.Ticket.DateFrom;
                model.Ticket.LeaveApprovedTo = model.Ticket.DateTo;
                model.Ticket.LeaveApprovedDate = currentTime;
            }
            else
            {
                model.Ticket.EmployeeId = Convert.ToInt32(Session["EmployeeId"].ToString());
            }
            model.Ticket.RecLastUpdatedBy = User.Identity.GetUserId();
            model.Ticket.RecLastUpdateOn = DateTime.UtcNow;

            ticketService.SaveTicket(model.Ticket.MapFromClientToServer());
            SendTicketGenerationEmailAlert(model);
            return RedirectToAction("Index");
        }
        private void SendTicketGenerationEmailAlert(TicketViewModel ticketViewModel)
        {
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            var employeeEmail = Session["EmployeeEmail"].ToString();
            var employeeData = employeeService.GetEmployeeData(ticketViewModel.Ticket.EmployeeId);
            List<string> employeeSupervisorsEmailsList = new List<string>();
            var ticketType = ticketTypeService.GetAllActiveTicketTypes().FirstOrDefault(x=>x.TicketTypeId == ticketViewModel.Ticket.TicketTypeId);
            if (ticketType != null && ticketType.IsLeave)
            {
                employeeSupervisorsEmailsList = employeeData.EmployeeSupervisors.ToList().Select(x => x.Supervisor.AspNetUser.Email).ToList();
                var HREmails = aspNetUserService.GetAllUsersEmailOfSpecificRole("HR");
                employeeSupervisorsEmailsList.AddRange(HREmails);

            }
            else
            {
                var HREmails = aspNetUserService.GetAllUsersEmailOfSpecificRole("HR");
                employeeSupervisorsEmailsList.AddRange(HREmails);
            }
            
            
            var employeeSupervisorsEmailsString = string.Join(",", employeeSupervisorsEmailsList);

            var employeeName = employeeData.Employee.FullName;
            var callbackUrl = Url.Action("Index", "Ticket", null, protocol: Request.Url.Scheme);
            string message = employeeName + " has generated a " + ticketViewModel.Ticket.TicketTitle + " Ticket on " +
                          Utility.ConvertTimeByGMT(GMT, currentTime) + ".<br/> Kindly review the details <a href=\"" + callbackUrl + "\">here</a>";

            UserManager.SendAttendanceEmailAsync(employeeEmail, ticketViewModel.Ticket.TicketTitle+" Ticket - Alert", message, employeeSupervisorsEmailsString);
        }
	}
}