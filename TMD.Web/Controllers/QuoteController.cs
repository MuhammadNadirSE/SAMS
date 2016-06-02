using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Web.ViewModels.Common;
using TMD.Web.ViewModels.Quote;
using TMD.Web.ModelMappers;
using TMD.Models.RequestModels;

namespace TMD.Web.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IQuoteService quoteService;
        public QuoteController(IQuoteService quoteService)
        {
            this.quoteService = quoteService;
        }
        // GET: /Quote/
        //[SiteAuthorize(PermissionKey = "InquiriesList")]
        public ActionResult Index()
        {
            //List<TMD.Web.Models.InquiryModel> Inquiries =
            //    inquiryService.GetAllInquiries()
            //        .ToList()
            //        .Select(x => x.MapServerToClient()).ToList();
           // ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            //return View(new InquiryViewModel());
            return View();
        }

        [HttpPost]
        public JsonResult Index(QuoteSearchRequest searchRequest)
        {

            //var contactResponse = inquiryService.GetAllInquiries(searchRequest);
            //var inquiryList = contactResponse.Inquiries.ToList().Select(x => x.MapServerToClientSearch()).ToList();
            //var model = new InquiryViewModel()
            //{
            //    data = inquiryList,
            //    recordsFiltered = contactResponse.FilteredCount,
            //    recordsTotal = contactResponse.TotalCount
            //};
           
           // return Json(model, JsonRequestBehavior.AllowGet);
            return null;
        }

        // GET: /Quote/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: /Quote/Create
        public ActionResult Create(int? id)
        {
            QuoteViewModel viewModel = new QuoteViewModel();

            var quoteResponse = quoteService.GetQuoteResponse(id);
            if (quoteResponse.Quote != null)
            {
                viewModel.Quote = quoteResponse.Quote.MapServerToClient();
                if (quoteResponse.Quote.QuoteDetails.FirstOrDefault() != null)
                    viewModel.Quote.QuoteDetail = quoteResponse.Quote.QuoteDetails.FirstOrDefault().MapServerToClient();
                if (quoteResponse.Quote.QuoteExclusions.FirstOrDefault() != null)
                    viewModel.QuoteExclusions = quoteResponse.Quote.QuoteExclusions.Select(x=>x.MapServerToClient()).ToList();
            }
            else
            {
                viewModel.Quote = new Models.QuoteModel
                {
                    CreatedDate = DateTime.UtcNow,
                    Subject = "Quotation for supply of ",
                    PaymentTerms = "70% on Product Delivery \n30% After installation",
                    DeliveryTerms = "1 - 2 Week(s)",
                    InstallationTerms = "1 Week(s)",
                    FreeServiceTerms = "6 Month(s)",
                    WarrantyTerms = "1 Year(s)",
                    ValidityTerms = "1 Week(s)"
                };
                viewModel.Quote.QuoteDetail.Make = "ZAMTAS";
            }
            viewModel.Contacts = quoteResponse.Contacts.Select(x => x.CreateDDL()).ToList();
            viewModel.Products = quoteResponse.Products.Select(x => x.CreateDDL()).ToList();
            viewModel.ProductModels = quoteResponse.ProductModels.Select(x => x.CreateDDL()).ToList();
            viewModel.Exclusions = quoteResponse.Exclusions.Select(x => x.MapServerToClient()).ToList();

            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(viewModel);
        }

        // POST: /Quote/Create
        [HttpPost]
        public ActionResult Create(QuoteViewModel viewModel)
        {
            try
            {
                viewModel.Quote.UpdatedDate = DateTime.UtcNow;
                viewModel.Quote.UpdatedBy = User.Identity.GetUserId();
                if (viewModel.Quote.QuoteID == 0)
                {
                    //viewModel.Quote.CreatedDate = DateTime.UtcNow;
                    viewModel.Quote.CreatedBy = User.Identity.GetUserId();
                }


                Quote quote = new Quote();


                quote = viewModel.Quote.MapClientToServer();

                quote.QuoteDetails = new List<QuoteDetail>
                {
                    viewModel.Quote.QuoteDetail.MapClientToServer()
                };
                quote.QuoteExclusions= viewModel.QuoteExclusions.Select(x => x.MapClientToServer()).ToList();

                if (quoteService.SaveQuote(quote))
                {
                    TempData["message"] = new MessageViewModel
                    {
                        IsSaved = true,
                        Message = "Your data has been saved successfully!"
                    };
                }
                else
                {
                    TempData["message"] = new MessageViewModel
                    {
                        IsError = true,
                        Message = "There is some problem, please try again!"
                    };
                }
                return RedirectToAction("Create");
            }
            catch (Exception e)
            {
                ViewBag.MessageVM = new MessageViewModel
                {
                    IsError = true,
                    Message = "There is some problem, please try again!"
                };
                return View(viewModel);
            }
        }
    }
}
