using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.Common;
using TMD.Web.ViewModels.Order;
using TMD.WebBase.Mvc;

namespace TMD.Web.Controllers
{
    public class OrderController : BaseController
    {
        #region Private

        private readonly IOrderService orderService;
        private readonly ICountryService countryService;
        private readonly IOrderStatusService orderStatusService;
        private readonly ICountyService countyService;

        #endregion

        #region Constructor

        public OrderController(IOrderService orderService, ICountryService countryService, IOrderStatusService orderStatusService, ICountyService countyService)
        {
            this.orderService = orderService;
            this.countryService = countryService;
            this.orderStatusService = orderStatusService;
            this.countyService = countyService;
        }

        #endregion

        #region Public

        #region Index
        [SiteAuthorize(PermissionKey = "OrderIndex")]
        public ActionResult Index()
        {

            OrderSearchRequest viewModel = Session["PageMetaData"] as OrderSearchRequest;

            Session["PageMetaData"] = null;
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            var toReturnModel = new OrderListViewModel
            {
                orderSearchRequest = viewModel ?? new OrderSearchRequest()
            };

            return View(toReturnModel);
        }

        [HttpPost]
        public ActionResult Index(OrderSearchRequest orderSearchRequest)
        {
            if (!User.IsInRole("Admin"))
            {
                orderSearchRequest.UserId = User.Identity.GetUserId();
            }
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            OrderResponse oResponse = orderService.GetAllOrders(orderSearchRequest);
            List<Models.Order> oList = oResponse.Orders.Select(x => x.CreateFromServerToClient()).ToList();
            OrderListViewModel oLVModel = new OrderListViewModel
            {
                data = oList,
                recordsTotal = oResponse.TotalCount,
                recordsFiltered = oResponse.FilteredCount
            };


            Session["PageMetaData"] = orderSearchRequest;
            var toReturn = Json(oLVModel, JsonRequestBehavior.AllowGet);
            return toReturn;
        }

        #endregion

        #region AddEdit

        public ActionResult AddEdit(long? id)
        {
            OrderViewModel viewModel = new OrderViewModel();
            if (id != null)
            {
                viewModel.Order = orderService.FindOrderById((long)id).CreateFromServerToClient();
            }
            viewModel.Counties = countyService.GetAll();
            viewModel.OrderStatuses = orderStatusService.GetAll();
            return View(viewModel);
        }

        [HttpPost]

        public ActionResult AddEdit(OrderViewModel orderViewModel)
        {
            try
            {
                //Update Case
                if (orderViewModel.Order.OrderId > 0)
                {
                    orderViewModel.Order.RecLastUpdatedBy = User.Identity.GetUserId();
                    orderViewModel.Order.RecLastUpdatedDt = DateTime.UtcNow;
                    Order orderToSave = orderViewModel.Order.CreateFromClientToServer();
                    if (orderService.UpdateOrder(orderToSave))
                    {
                        TempData["message"] = new MessageViewModel
                        {
                            Message = "Order Successfully Updated",
                            IsUpdated = true
                        };
                        return RedirectToAction("Index");
                    }
                }
                //Add Case
                else
                {
                    orderViewModel.Order.RecCreatedBy = User.Identity.GetUserId();
                    orderViewModel.Order.RecCreatedDt = DateTime.UtcNow;
                    orderViewModel.Order.RecLastUpdatedBy = User.Identity.GetUserId();
                    orderViewModel.Order.RecLastUpdatedDt = DateTime.UtcNow;
                    Order orderToSave = orderViewModel.Order.CreateFromClientToServer();
                    if (orderService.SaveOrder(orderToSave))
                    {
                        TempData["message"] = new MessageViewModel
                        {
                            Message = "Order Successfully Saved",
                            IsSaved = true
                        };
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception e)
            {
                TempData["message"] = new MessageViewModel { Message = e.Message, IsError = true };
                return RedirectToAction("Create", e);
            }
            return View(orderViewModel);
        }

        #endregion

        #endregion
    }
}