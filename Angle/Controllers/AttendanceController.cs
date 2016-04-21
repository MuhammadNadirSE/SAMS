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
using TMD.Models.Common;
using TMD.Models.RequestModels;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels.Attendance;
using TMD.Web.ViewModels.Common;
using TMD.WebBase.Mvc;


namespace TMD.Web.Controllers
{
    public class AttendanceController : BaseController
    {
        private readonly IAttendanceService attendanceService;
        private readonly IEmployeeService employeeService;
        private readonly ITicketService ticketService;
        private readonly IAspNetUserService aspNetUserService;
        private ApplicationUserManager _userManager;
        private DateTime currentTime = DateTime.UtcNow;
        //private readonly int = 
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public AttendanceController(IAttendanceService attendanceService, IEmployeeService employeeService, ITicketService ticketService, IAspNetUserService aspNetUserService)
        {
            this.attendanceService = attendanceService;
            this.employeeService = employeeService;
            this.ticketService = ticketService;
            this.aspNetUserService = aspNetUserService;
        }
        [SiteAuthorize(PermissionKey = "ViewAttendance")]
        public ActionResult Index()
        {
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            var model = new AttendanceWebViewModel();
            var employees = employeeService.GetAllEmployees().ToList().Select(x => x.CreateFromServerToClient(GMT)).OrderBy(x=>x.FullName).ToList();
            model.Employees = employees;
            model.AttendanceSearchRequest.EmployeeId = (int) Session["EmployeeID"];
            model.AttendanceSearchRequest.SortBy = 0;
            model.AttendanceSearchRequest.Date = currentTime;
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Index(AttendanceSearchRequest searchRequest)
        {
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            string[] userPermissionsSet = (string[]) System.Web.HttpContext.Current.Session["UserPermissionSet"];

            if (!userPermissionsSet.Contains("ViewAllEmployeeAttendance"))
                searchRequest.EmployeeId = (int)Session["EmployeeID"];
            var attendanceresponse = attendanceService.GetAllAttendances(searchRequest);
            var attendanceList = attendanceresponse.Attendances.ToList().Select(x => x.MapAttendanceResponseFromServerToClient(GMT)).ToList();
            var model = new AttendanceWebViewModel
            {
                data = attendanceList,
                recordsFiltered = attendanceresponse.FilteredCount,
                recordsTotal = attendanceresponse.TotalCount
            };
            if (searchRequest.Date.Year != 1)
            {
                TimeSpan totalWorkingHoursTimeSpan = attendanceList.Select(x => TimeSpan.Parse(x.WorkingHours)).Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal.Add(t));
                model.TotalWorkingHours = Math.Round(totalWorkingHoursTimeSpan.TotalHours, 2) ;
                
                double avg = Math.Round(totalWorkingHoursTimeSpan.TotalHours/Convert.ToDouble(model.data.Count), 2);

                model.AvgWorkingHours = Double.IsNaN(avg) ? 0 : avg;
                model.TotalWorkingDays = model.data.Count;
            }
            else
            {
                model.TotalWorkingHours = 0;
            }
            

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CheckIn()
        {
            EmployeeAttendanceStatus status;
            if (attendanceService.GetAttendanceByEmployeeIdInCurrentDate((int) Session["EmployeeID"]) == null)
            {
                status = EmployeeAttendanceStatus.CheckedIn;
                Session["UserAttendanceStatus"] = status;

                var attendanceWebModel = new AttendanceModel
                {
                    RecCreatedBy = User.Identity.GetUserId(),
                    RecCreatedDate = currentTime,
                    RecLastUpdatedBy = User.Identity.GetUserId(),
                    RecLastUpdatedDate = currentTime,
                    EmployeeId = (int) Session["EmployeeID"],
                    CheckInTime = currentTime,
                    //CheckOutTime = new DateTime(currentTime.Year,currentTime.Month,currentTime.Day,15,0,0),
                    IsEdited = false,
                    Status = (int)status
                };
                
                var lateArrival = Convert.ToInt32(ConfigurationManager.AppSettings["LateArrivalWarning"]);
                var lateArrivalLeave = Convert.ToInt32(ConfigurationManager.AppSettings["ArrivalLeaveMarked"]);
                
                var lateTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, lateArrival, 0, 0);
                var lateTimeWithLeave = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, lateArrivalLeave, 0, 0);
                
                if(attendanceWebModel.CheckInTime > lateTimeWithLeave)
                    SendAttendanceEmailAlert(attendanceWebModel, true);

                if (attendanceWebModel.CheckInTime > lateTime && attendanceWebModel.CheckInTime < lateTimeWithLeave)
                    SendAttendanceEmailAlert(attendanceWebModel, false);

                attendanceService.SaveAttendance(attendanceWebModel.MapFromClientToServer());
            }
            else
                status = EmployeeAttendanceStatus.AlreadyInToday;

            
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        private void SendAttendanceEmailAlert(AttendanceModel attendanceWebModel, bool threshHold)
        {
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            var employeeEmail = Session["EmployeeEmail"].ToString();
            var employeeData = employeeService.GetEmployeeData(attendanceWebModel.EmployeeId);

            List<string> employeeSupervisorsEmailsList = employeeData.EmployeeSupervisors.ToList().Select(x => x.Supervisor.AspNetUser.Email).ToList();
            var HrEmails = aspNetUserService.GetAllUsersEmailOfSpecificRole("HR");
            employeeSupervisorsEmailsList.AddRange(HrEmails);
            
            var employeeSupervisorsEmailsString = string.Join(",", employeeSupervisorsEmailsList);

            var employeeName = employeeData.Employee.FullName;
            string threshHoldMessage = string.Empty;
            if (threshHold)
            {
                threshHoldMessage = " and half leave has been marked for today";
                TicketModel ticket = new TicketModel
                {
                    EmployeeId = Convert.ToInt32(Session["EmployeeId"].ToString()),
                    TicketTypeId = Convert.ToInt32(ConfigurationManager.AppSettings["HalfDayLeave"]),
                    RecCreatedBy = User.Identity.GetUserId(),
                    RecLastUpdatedBy = User.Identity.GetUserId(),
                    RecCreatedOn = currentTime,
                    RecLastUpdateOn = currentTime,
                    Reason = "This is auto generated reason, Employee Check-in time was " + Utility.ConvertTimeByGMT(GMT, currentTime)
                };
                ticketService.SaveTicket(ticket.MapFromClientToServer());
            }
            string message = employeeName +" is late,"+ threshHoldMessage +" . Employee Checked-in at " +
                          Utility.ConvertTimeByGMT(GMT, currentTime) + ". <br/><i>Admin has been notified by email.</i>";

            UserManager.SendAttendanceEmailAsync(employeeEmail, "Late Attendance - Alert", message, employeeSupervisorsEmailsString);
        }

        [HttpPost]
        public JsonResult CheckOut()
        {
            if ((EmployeeAttendanceStatus) Session["UserAttendanceStatus"] != EmployeeAttendanceStatus.CheckedOut)
            {
                Session["UserAttendanceStatus"] = EmployeeAttendanceStatus.CheckedOut;
                var attendance = attendanceService.GetAttendanceByEmployeeIdInCurrentDate((int)Session["EmployeeID"]);
                
                
                attendance.CheckOutTime = currentTime;
                attendance.Status = (int)EmployeeAttendanceStatus.CheckedOut;

                if (attendance.AwayFromTime != null && attendance.AwayToTime == null)
                {
                    attendance.AwayToTime = currentTime;
                }

                attendance.RecLastUpdatedBy = User.Identity.GetUserId();
                attendance.RecLastUpdatedDate = currentTime;
                attendanceService.SaveAttendance(attendance);
            }
            
            return Json(EmployeeAttendanceStatus.CheckedOut, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult Away()
        {
            var status = EmployeeAttendanceStatus.Away;
            if ((EmployeeAttendanceStatus) Session["UserAttendanceStatus"] != EmployeeAttendanceStatus.Away)
            {
                Session["UserAttendanceStatus"] = EmployeeAttendanceStatus.Away;
                var attendance = attendanceService.GetAttendanceByEmployeeIdInCurrentDate((int) Session["EmployeeID"]);
                attendance.RecLastUpdatedBy = User.Identity.GetUserId();
                attendance.RecLastUpdatedDate = currentTime;
                attendance.Status = (int) EmployeeAttendanceStatus.Away;
                if (attendance.AwayFromTime == null)
                {
                    attendance.AwayFromTime = currentTime;
                    attendanceService.SaveAttendance(attendance);
                    return Json(status, JsonRequestBehavior.AllowGet);
                }
                
            }
            return Json(EmployeeAttendanceStatus.AlreadyAway, JsonRequestBehavior.AllowGet);
            
        }
        
        [HttpPost]
        public JsonResult Available()
        {
            if ((EmployeeAttendanceStatus) Session["UserAttendanceStatus"] != EmployeeAttendanceStatus.Available)
            {
                Session["UserAttendanceStatus"] = EmployeeAttendanceStatus.Available;
                var attendance = attendanceService.GetAttendanceByEmployeeIdInCurrentDate((int)Session["EmployeeID"]);
                attendance.RecLastUpdatedBy = User.Identity.GetUserId();
                attendance.RecLastUpdatedDate = currentTime;
                if (attendance.AwayToTime == null)
                {
                    attendance.AwayToTime = currentTime;
                }
                attendance.Status = (int) EmployeeAttendanceStatus.Available;
                attendanceService.SaveAttendance(attendance);
            }
            
            return Json(EmployeeAttendanceStatus.Available, JsonRequestBehavior.AllowGet);
        }

        [SiteAuthorize(PermissionKey = "EditAttendance")]
        public ActionResult Edit(long id)
        {
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            var model = attendanceService.GetAttendanceById(id).MapFromServerToClient(GMT);
            return View(model);
        }
        
        [SiteAuthorize(PermissionKey = "EditAttendance")]
        [HttpPost]
        public ActionResult Edit(AttendanceModel attendanceModel)
        {
            attendanceModel.RecLastUpdatedBy = User.Identity.GetUserId();
            attendanceModel.RecLastUpdatedDate = currentTime;

            var empId = (int) Session["EmployeeID"];
            
            attendanceModel.EditedBy = empId;
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            attendanceModel.EditedDate = currentTime;
            attendanceModel.CheckInTime = Utility.SubtractTimeByGMT(GMT,attendanceModel.CheckInTime);
            if (attendanceModel.CheckOutTime!=null)
                attendanceModel.CheckOutTime = Utility.SubtractTimeByGMT(GMT, Convert.ToDateTime(attendanceModel.CheckOutTime));
            attendanceModel.AwayFromTime = attendanceModel.AwayFromTime != null ? Utility.SubtractTimeByGMT(GMT, attendanceModel.AwayFromTime.Value) : attendanceModel.AwayFromTime;
            attendanceModel.AwayToTime = attendanceModel.AwayToTime != null ? Utility.SubtractTimeByGMT(GMT,attendanceModel.AwayToTime.Value) : attendanceModel.AwayToTime;

            var IsSaved = attendanceService.SaveAttendance(attendanceModel.MapFromClientToServer());
            if (IsSaved)
                TempData["Message"] = new MessageViewModel{IsUpdated = true, Message = "Attendance has been updated successfully."};
            else
                TempData["Message"] = new MessageViewModel { IsError = true, Message = "Something went wrong." };
            return RedirectToAction("Index");
        }

        [SiteAuthorize(PermissionKey = "ManualAttendance")]
        public ActionResult Manual()
        {
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            var model = new AttendanceModel
            {
                Employees = employeeService.GetAllEmployees().ToList().Select(x => x.MapEmployeeDdlFromServerToClient()).ToList(),
                CheckInTime = Utility.ConvertTimeByGMT(GMT,currentTime)
            };


            return View(model);
        }
        
        [SiteAuthorize(PermissionKey = "ManualAttendance")]
        [HttpPost]
        public ActionResult Manual(AttendanceModel attendanceModel)
        {
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            //var empId = (int)Session["EmployeeID"];

            if (attendanceModel.AttendanceId == 0)
            {
                attendanceModel.RecCreatedBy = User.Identity.GetUserId();
                attendanceModel.RecCreatedDate = currentTime;
            }

            attendanceModel.RecLastUpdatedBy = User.Identity.GetUserId();
            attendanceModel.RecLastUpdatedDate = currentTime;
            attendanceModel.IsEdited = false;
            
            attendanceModel.CheckInTime = Utility.SubtractTimeByGMT(GMT, attendanceModel.CheckInTime);
            if (attendanceModel.CheckOutTime != null)
                attendanceModel.CheckOutTime = Utility.SubtractTimeByGMT(GMT, Convert.ToDateTime(attendanceModel.CheckOutTime));
            attendanceModel.AwayFromTime = attendanceModel.AwayFromTime != null ? Utility.SubtractTimeByGMT(GMT, attendanceModel.AwayFromTime.Value) : attendanceModel.AwayFromTime;
            attendanceModel.AwayToTime = attendanceModel.AwayToTime != null ? Utility.SubtractTimeByGMT(GMT, attendanceModel.AwayToTime.Value) : attendanceModel.AwayToTime;


            var IsSaved = attendanceService.SaveAttendance(attendanceModel.MapFromClientToServer());
            if (IsSaved)
                TempData["Message"] = new MessageViewModel { IsUpdated = true, Message = "Attendance has been marked successfully." };
            else
                TempData["Message"] = new MessageViewModel { IsError = true, Message = "Something went wrong." };
            return RedirectToAction("Index");
        }


	}
}