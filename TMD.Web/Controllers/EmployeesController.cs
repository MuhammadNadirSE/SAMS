using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.BaseDataModels;
using TMD.Models.DomainModels;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.Common;
using TMD.Web.ViewModels.Employee;
using TMD.WebBase.Mvc;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class EmployeesController : BaseController
    {

        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [SiteAuthorize(PermissionKey = "EmployeeIndex")]
        public ActionResult Index()
        {
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            ViewBag.CallBackURL = Session["callbackUrl"];
            Session["callbackUrl"] = null;
            string[] userPermissionsSet = (string[])System.Web.HttpContext.Current.Session["UserPermissionSet"];
            if (userPermissionsSet.Contains("ViewEmployees"))
            {
                var GMT = Convert.ToInt32(Session["ClientGMT"]);
                ViewBag.MessageVM = TempData["message"] as MessageViewModel;
                List<EmployeeModel> employees =
                    employeeService.GetAllEmployees().ToList().Select(x => x.CreateFromServerToClient(GMT)).ToList();

                return View(employees);
            }
            return RedirectToAction("Create", "Employees", new { id = Session["EmployeeID"] });
        }
        public ActionResult Create(int? id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.Employee.IsRegistered = true;
            var employeeBasedata = employeeService.GetEmployeeData(id);
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            if (employeeBasedata.Employee != null)
            {
                employeeViewModel.Employee = employeeBasedata.Employee.CreateFromServerToClient(GMT);
            }
            if (employeeBasedata.EmployeePhoto != null)
            {
                employeeViewModel.EmployeePhoto = employeeBasedata.EmployeePhoto;
            }
            employeeViewModel.Designation = employeeBasedata.Designation.Select(x => x.CreateFromServerToClient()).OrderBy(x=>x.Title).ToList();

            var roles = Session["RoleName"].ToString().ToLower() == "superadmin"
                ? employeeBasedata.Role
                : employeeBasedata.Role.Where(x => x.Name != "SuperAdmin").ToList();
            employeeViewModel.Roles = roles.Select(x => x.CreateFromServerToClient()).OrderBy(x=>x.Name).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(employeeViewModel);
        }
        //[HttpPost]
        public ActionResult AddEmployee()
        {
            EmployeeViewModel employeeViewModel = TempData["EmployeeViewModel"] as EmployeeViewModel;
            if (employeeViewModel != null)
            {
                if (employeeViewModel.Employee.EmployeeId == 0)
                {
                    employeeViewModel.Employee.RecCreatedBy = User.Identity.GetUserId();
                    employeeViewModel.Employee.RecCreatedDt = DateTime.UtcNow;
                }
                employeeViewModel.Employee.RecLastUpdatedBy = User.Identity.GetUserId();
                employeeViewModel.Employee.RecLastUpdatedDt = DateTime.UtcNow;

                EmployeeBaseData employeeData = new EmployeeBaseData();
                employeeData.Employee = employeeViewModel.Employee.CreateFromClientToServer();
                if (employeeViewModel.UploadFile != null)
                {
                    var tempStream = employeeViewModel.UploadFile.InputStream;
                    byte[] bytes = new byte[tempStream.Length];
                    tempStream.Read(bytes, 0, Convert.ToInt32(tempStream.Length));
                    Document document = new Document
                    {
                        DocumentData = bytes,
                        DocumentName = employeeViewModel.UploadFile.FileName,
                        DocumentType = employeeViewModel.UploadFile.ContentType
                    };
                    if (employeeViewModel.EmployeePhoto!=null && employeeViewModel.EmployeePhoto.DocumentId > 0)
                        document.DocumentId = employeeViewModel.EmployeePhoto.DocumentId;
                    employeeData.EmployeePhoto = document;
                }
                //if (employeeViewModel.EmployeeSupervisor != null)
                //    employeeData.EmployeeSupervisors = employeeViewModel.EmployeeSupervisor.Select(x => x.CreateFromClientToServer()).ToList();
                employeeService.SaveEmployee(employeeData);
            }
            TempData["message"] = new MessageViewModel
            {
                IsSaved = true,
                Message = "Your data has been saved successfully!"
            };
            return RedirectToAction("Index");
        }


    }
}
