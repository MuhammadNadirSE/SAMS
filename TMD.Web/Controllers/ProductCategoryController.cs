using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Web.ViewModels.ProductCategory;
using TMD.Web.ModelMappers;
using System.Collections.Generic;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class ProductCategoryController : BaseController
    {
        private readonly IProductCategoryService productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }
        //
        // GET: /ProductCategory/
        public ActionResult Index()
        {
            List<TMD.Web.Models.ProductCategoryModel> productCategories =
                productCategoryService.GetAllCategories()
                    .ToList()
                    .Select(x => x.MapServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(productCategories);
          
        }

        //
        // GET: /ProductCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ProductCategory/Create
        public ActionResult Create(int? id)
        {
            ProductCategoryViewModel productCategoryViewModel = new ProductCategoryViewModel();
           
                var prodCatResp=productCategoryService.GetProductCategoryResponse(id);
                productCategoryViewModel.ProductCategory = prodCatResp.ProductCategory != null ? prodCatResp.ProductCategory.MapServerToClient() : new Models.ProductCategoryModel();

                productCategoryViewModel.ProductCategories = prodCatResp.ProductCategories.Select(x => x.MapServerToClient()).ToList();

            ViewBag.ReturnUrl = Request.QueryString["returnUrl"];
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(productCategoryViewModel);
        }

        //
        // POST: /ProductCategory/Create
        [HttpPost]
        public ActionResult Create(ProductCategoryViewModel productCategoryViewModel)
        {
            try
            {
                productCategoryViewModel.ProductCategory.UpdatedDate = DateTime.UtcNow;
                productCategoryViewModel.ProductCategory.UpdatedBy = User.Identity.GetUserId();
                // TODO: Add insert logic here
                if (productCategoryViewModel.ProductCategory.ProductCategoryID > 0)
                {
                    productCategoryService.UpdateCategory(productCategoryViewModel.ProductCategory.MapClientToServer());
                }
                else
                {
                    productCategoryViewModel.ProductCategory.CreatedDate = DateTime.UtcNow;
                    productCategoryViewModel.ProductCategory.CreatedBy = User.Identity.GetUserId();

                    productCategoryService.AddCategory(productCategoryViewModel.ProductCategory.MapClientToServer());
                }
                TempData["message"] = new MessageViewModel
                {
                    IsSaved = true,
                    Message = "Your data has been saved successfully!"
                };
                if (string.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                    return RedirectToAction("Create");
                return Redirect(Request.QueryString["returnUrl"]);
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
