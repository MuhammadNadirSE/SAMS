using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf.qrcode;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.RequestModels;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.Common;
using TMD.Web.ViewModels.Payroll;
using TMD.WebBase.Mvc;

namespace TMD.Web.Controllers
{
    public class PayrollController : BaseController
    {
        #region Private
        private readonly IEmployeePayrollService payrollService;
        private IEmployeeService employeeService;

        /// <summary>
        /// Helper Swap function
        /// </summary>
        /// <param name="list"></param>
        /// <param name="basicSalaryIndex"></param>
        /// <param name="zeroIndex"></param>
        private void Swap(List<EmployeePayrollModel> list, int basicSalaryIndex, int zeroIndex)
        {
            var temp = list[basicSalaryIndex];
            list[basicSalaryIndex] = list[zeroIndex];
            list[zeroIndex] = temp;
        }
        #endregion

        #region Constructor
        public PayrollController(IEmployeePayrollService payrollService, IEmployeeService employeeService)
        {
            this.payrollService = payrollService;
            this.employeeService = employeeService;
        }

        #endregion

        #region Public
        [SiteAuthorize(PermissionKey = "ViewPayRoll")]
        public ActionResult Index()
        {
            var model = new PayrollListViewModel();
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            var employees = employeeService.GetAllEmployees().ToList().Select(x => x.CreateFromServerToClient(GMT)).OrderBy(x => x.FullName).ToList();
            model.Employees = employees;
            
            model.PayrollSearchRequest.EmployeeId = (int)Session["EmployeeID"];
            model.PayrollSearchRequest.SortBy = 0;
            model.PayrollSearchRequest.Date = DateTime.UtcNow;
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(model);
        }
        
        [HttpPost]
        public JsonResult Index(PayrollSearchRequest searchRequest)
        {
            if (!(User.IsInRole("Admin") || User.IsInRole("HR")))
                searchRequest.EmployeeId = (int)Session["EmployeeID"];
            var payrollResponse = payrollService.GetAllPayrolls(searchRequest);
            var payrollList = payrollResponse.EmployeePayrollGroupBy.ToList().Select(x => x.CreatePayRollFromServerToClient()).ToList();
            var model = new PayrollListViewModel
            {
                data = payrollList,
                recordsFiltered = payrollResponse.FilteredCount,
                recordsTotal = payrollResponse.TotalCount
            };
            //var obj = new {data = model.EmployeePayrolls, model};
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
        // GET: Payroll
        [SiteAuthorize(PermissionKey = "CreatePayroll")]
        public ActionResult Create(int? Eid,DateTime? M)
        {
            var payrollBaseaData = payrollService.GetPayrollData(Eid,M);
            var GMT = Convert.ToInt32(Session["ClientGMT"]);
            var model = new PayrollCreateViewModel
            {

                Employees = payrollBaseaData.Employees.Select(x => x.CreateFromServerToClient(GMT)).OrderBy(x=>x.FullName).ToList(),
                AllowanceTypes = payrollBaseaData.AllowanceTypes.ToList().Select(x => x.CreateFromServerToClient()).OrderBy(x=>x.TypeTitle).ToList(),
                EmployeePayrolls = payrollBaseaData.EmployeePayrolls.ToList().Select(x=>x.CreateFromServerToClient()).ToList(),
            };

            if (Eid != null)
            {
                if (model.EmployeePayrolls.Any(x => x.AllowanceTypeId == Convert.ToInt32(ConfigurationManager.AppSettings["BasicSalaryId"].ToString())))
                    Swap(model.EmployeePayrolls, model.EmployeePayrolls.FindIndex(x => x.AllowanceTypeId == Convert.ToInt32(ConfigurationManager.AppSettings["BasicSalaryId"].ToString())), 0);
                model.AllowanceMonth = M;
                model.Eid = Eid;
                model.TotalAllowance = model.EmployeePayrolls.Sum(x => x.Amount);
            }
            return View(model);
        }
        
        [HttpPost]
        [SiteAuthorize(PermissionKey = "AddAllowance")]
        public ActionResult Create(PayrollCreateViewModel payrollModel)
        {
            payrollModel.EmployeePayrolls[0].AllowanceMonth = (DateTime)payrollModel.AllowanceMonth;
            var payrollToBeSaved = payrollModel.EmployeePayrolls.Select(x => x.CreateFromClientToServer(User.Identity.GetUserId())).ToList();
            payrollService.SaveUpdate(payrollToBeSaved);
            TempData["Message"] = new MessageViewModel { IsSaved = true, Message = "Payroll has been saved successfully." };
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result = payrollService.Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}