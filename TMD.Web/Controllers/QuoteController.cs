using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.ViewModels.Common;
using TMD.Web.ViewModels.Quote;
using TMD.Web.ModelMappers;

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
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Quote/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: /Quote/Create
        public ActionResult Create(int? id)
        {
            QuoteViewModel viewModel = new QuoteViewModel
            {
                Quote = new Models.QuoteModel { CreatedDate = DateTime.UtcNow }
            };

            var quoteResponse = quoteService.GetQuoteResponse(id);
            if (quoteResponse.Quote != null)
            {
                viewModel.Quote = quoteResponse.Quote.MapServerToClient();
                if (quoteResponse.Quote.QuoteDetails.FirstOrDefault() != null)
                    viewModel.Quote.QuoteDetail = quoteResponse.Quote.QuoteDetails.FirstOrDefault().MapServerToClient();
            }

            viewModel.Contacts = quoteResponse.Contacts.Select(x => x.CreateDDL()).ToList();
            viewModel.Products = quoteResponse.Products.Select(x => x.CreateDDL()).ToList();
            viewModel.ProductModels = quoteResponse.ProductModels.Select(x => x.CreateDDL()).ToList();

            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(viewModel);
        }

        // POST: /Quote/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
