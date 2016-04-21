using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.Case;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class CaseController : BaseController
    {

        #region Private

        private readonly ICaseService caseService;
        private readonly IOrderService orderService;
        private readonly IChargeService chargeService;

        #endregion

        #region Constructor

        public CaseController(ICaseService caseService, IOrderService orderService, IChargeService chargeService)
        {
            this.caseService = caseService;
            this.orderService = orderService;
            this.chargeService = chargeService;
        }

        #endregion

        #region Public

        #region Index

        public ActionResult Index(long id)
        {
            CaseListViewModel viewModel = new CaseListViewModel
            {
                Cases = caseService.FindCaseByOrderId(id).Select(x => x.CreateFromServerToClient()).ToList(),
                Order = orderService.FindOrderById(id).CreateFromServerToClient(),
                OrderId = id
            };
            return View(viewModel);
        }

        #endregion

        #region AddEdit

        public ActionResult AddEdit(long? id, long orderId)
        {
            CaseViewModel caseViewModel = new CaseViewModel();
            if (id != null)
            {
                caseViewModel.Charges = chargeService.FindChargeByCaseId((long)id).Select(x => x.CreateFromServerToClient()).ToList();
                caseViewModel.Case = caseService.FindCaseById((long)id).CreateFromServerToClient();
            }
            caseViewModel.Order = orderService.FindOrderById(orderId).CreateFromServerToClient();
            caseViewModel.OrderId = orderId;
            return View(caseViewModel);
        }

        [HttpPost]

        public ActionResult AddEdit(CaseViewModel caseViewModel)
        {
            CaseRequest caseToSave = new CaseRequest
            {
                Case = caseViewModel.Case.CreateFromClientToServer(),
                OrderId = caseViewModel.OrderId,
                Charges = caseViewModel.Charges.Select(x => x.CreateFromClientToServer()).ToList()
            };
            caseToSave.Case.OrderId = caseViewModel.OrderId;
            caseService.SaveCase(caseToSave);
            {
                TempData["message"] = new MessageViewModel { Message = "Case Detail Saved", IsSaved = true };
                return RedirectToAction("Index", "Order");
            }
        }

        #endregion

        #endregion

    }
}