using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Angle.Controllers;
using Angle.ViewModels.Common;
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
                employeeViewModel.RemainingCasualLeaves = employeeBasedata.RemainingCasualLeaves;
                employeeViewModel.RemainingMedicalLeaves = employeeBasedata.RemainingMedicalLeaves;
                employeeViewModel.RemainingPaidLeaves = employeeBasedata.RemainingPaidLeaves;

                employeeViewModel.Employee = employeeBasedata.Employee.CreateFromServerToClient(GMT);
                employeeViewModel.EmployeesSupervisors = employeeBasedata.EmployeeSupervisors.Select(x => x.Supervisor.CreateFromServerToClient(GMT)).ToList();
            }
            employeeViewModel.Designation = employeeBasedata.Designation.Select(x => x.CreateFromServerToClient()).OrderBy(x=>x.Title).ToList();
            employeeViewModel.Employees = employeeBasedata.Employees.Select(x => x.CreateFromServerToClient(GMT)).OrderBy(x=>x.FullName).ToList();
            employeeViewModel.Roles = employeeBasedata.Role.Select(x => x.CreateFromServerToClient()).OrderBy(x=>x.Name).ToList();
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
                if (employeeViewModel.EmployeeSupervisor != null)
                    employeeData.EmployeeSupervisors = employeeViewModel.EmployeeSupervisor.Select(x => x.CreateFromClientToServer()).ToList();
                employeeService.SaveEmployee(employeeData);
            }
            return RedirectToAction("Index");
        }


    }
}
