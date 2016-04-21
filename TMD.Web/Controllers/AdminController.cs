using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.ResponseModels;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.Dashboard;
using TMD.WebBase.Mvc;

namespace TMD.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IOrderService orderService;

        public AdminController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        //[SiteAuthorize(PermissionKey = "AdminHome")]
        public ActionResult Home()
        {
            DashboardViewModel viewModel = new DashboardViewModel();
            DashboardResponse response = null;
            if (User.IsInRole("Admin"))
            {
                response = orderService.GetOrdersForDashboard(null);
            }
            else
            {
                string userId = User.Identity.GetUserId();
                response = orderService.GetOrdersForDashboard(userId);
            }
            viewModel.CompletedOrders = response.completedOrders.Select(x=>x.CreateFromServerToClient());
            viewModel.NewOrders = response.newOrders.Select(x=>x.CreateFromServerToClient());
            viewModel.completedOrderCount = response.completedOrderCount;
            viewModel.newOrderCount = response.newOrderCount;
            viewModel.pendingOrderCount = response.pendingOrderCount;
            viewModel.submittedOrderCount = response.submittedOrderCount;
            return View(viewModel);
        }
    }
}
public class HttpHeaderAttribute : ActionFilterAttribute
{
    public string Name { get; set; }
    public string Value { get; set; }
    public HttpHeaderAttribute(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public override void OnResultExecuted(ResultExecutedContext filterContext)
    {
        filterContext.HttpContext.Response.AppendHeader(Name, Value);
        base.OnResultExecuted(filterContext);
    }
}