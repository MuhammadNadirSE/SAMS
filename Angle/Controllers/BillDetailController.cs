using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Angle.ModelMappers;
using Angle.ViewModels.BillDetail;
using Angle.ViewModels.Common;
using TMD.Interfaces.IServices;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace Angle.Controllers
{
    public class BillDetailController : BaseController
    {
        #region Private

        private readonly IBillDetailService billDetailService;

        #endregion

        #region Constructor

        public BillDetailController(IBillDetailService billDetailService)
        {
            this.billDetailService = billDetailService;
        }

        #endregion

        #region Public

        #region Index

        public ActionResult Index()
        {
            BillDetailSearchRequest viewModel = Session["PageMetaData"] as BillDetailSearchRequest;
            Session["PageMetaData"] = null;
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            var returnViewModel = new BillDetailListViewModel
            {
                SearchRequest = viewModel ?? new BillDetailSearchRequest()
            };

            return View(returnViewModel);
        }

        [HttpPost]
        public ActionResult Index(BillDetailSearchRequest searchRequest)
        {
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            BillDetailResponse oResponse = billDetailService.GetAllBillDetails(searchRequest);
            List<Models.BillDetail> list = oResponse.BillDetails.Select(x => x.CreateFromServerToClient()).ToList();
            BillDetailListViewModel listViewModel = new BillDetailListViewModel
            {
                data = list,
                recordsTotal = oResponse.TotalCount,
                recordsFiltered = oResponse.FilteredCount
            };


            Session["PageMetaData"] = searchRequest;
            var toReturn = Json(listViewModel, JsonRequestBehavior.AllowGet);
            return toReturn;
        }

        #endregion

        #region AddEdit
        #endregion


        #endregion
    }
}