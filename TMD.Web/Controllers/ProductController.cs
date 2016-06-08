using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.ResponseModels;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.Common;
using TMD.Web.ViewModels.Product;
using TMD.WebBase.Mvc;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IProductModelService productModelService;

        public ProductController(IProductService productService, IProductModelService productModelService)
        {
            this.productService = productService;
            this.productModelService = productModelService;
        }

        [SiteAuthorize(PermissionKey = "ProductsList")]
        public ActionResult Index()
        {
            List<Models.Product> products =
                productService.GetAllProducts()
                    .ToList()
                    .Select(x => x.MapServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(products);
        }

        [SiteAuthorize(PermissionKey = "CreateUpdateProduct")]
        public ActionResult Create(int ?ID)
        {
            ProductViewModel productViewModel = new ProductViewModel();

            var prodResp = productService.GetProductResponse(ID);
            if (prodResp.Product != null)
            {
                productViewModel.Product = prodResp.Product.MapServerToClient();
            }
            else
            {
                productViewModel.Product = new Models.Product
                {
                    DetailDescription = string.Empty
                };
            }

            productViewModel.ProductCategories = prodResp.ProductCategories.Select(x => x.MapServerToClient()).ToList();

            ViewBag.ReturnUrl = Request.QueryString["returnUrl"];
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(productViewModel);
        }

        [SiteAuthorize(PermissionKey = "CreateUpdateProduct")]
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            try
            {
                productViewModel.Product.UpdatedDate = DateTime.UtcNow;
                productViewModel.Product.UpdatedBy = User.Identity.GetUserId();
                // TODO: Add insert logic here
                if (productViewModel.Product.ProductID > 0)
                {
                    TempData["ProductId"] = productService.UpdateProduct(productViewModel.Product.MapClientToServer());
                }
                else
                {
                    productViewModel.Product.CreatedDate = DateTime.UtcNow;
                    productViewModel.Product.CreatedBy = User.Identity.GetUserId();

                    TempData["ProductId"] = productService.AddProduct(productViewModel.Product.MapClientToServer());
                }
                TempData["message"] = new MessageViewModel
                {
                    IsSaved = true,
                    Message = "Your data has been saved successfully!"
                };
                if (string.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                    return RedirectToAction("ModelSpecs", new { product = (int)TempData["ProductId"]});
                return RedirectToAction("ModelSpecs", new { product = (int)TempData["ProductId"], returnUrl = Request.QueryString["returnUrl"] });
            }
            catch (Exception ex)
            {
                return View(productViewModel);
            }
        }
        [SiteAuthorize(PermissionKey = "CreateUpdateProduct")]
        public ActionResult ModelSpecs(int? product,int? model)
        {
            if(product==null || product<1 )
                return RedirectToAction("Create");

            ProductModelViewModel viewModel = new ProductModelViewModel();

            var prodResp = productModelService.GetProductModelResponse(product,model);
            if (prodResp.ProductModels.Any())
            {
                viewModel.ProductModels = prodResp.ProductModels.ToList().Select(x => x.MapServerToClient()).ToList();
            }
            if (prodResp.ProductModel != null)
            {
                viewModel.ProductModel = prodResp.ProductModel.MapServerToClient();
                viewModel.ProductTechnicalSpec = prodResp.ProductModelTechnicalSpec.ToList().Select(x=>x.MapServerToClient()).ToList();
            }
            else
            {
                viewModel.ProductModel = new Models.ProductModel
                {
                    ProductId= (int)product
                };
            }

            viewModel.TechnicalSpecs = prodResp.TechnicalSpec.Select(x => x.CreateDropDownList()).ToList();

            ViewBag.ReturnUrl = Request.QueryString["returnUrl"];
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(viewModel);
        }
        [SiteAuthorize(PermissionKey = "CreateUpdateProduct")]
        [HttpPost]
        public ActionResult ModelSpecs(ProductModelViewModel viewModel)
        {
            try
            {
                ProductModelResponse contactResp = new ProductModelResponse();

                contactResp.ProductModel = viewModel.ProductModel.MapClientToServer();
                if (viewModel.TechnicalSpecs != null)
                    contactResp.ProductModelTechnicalSpec = viewModel.ProductTechnicalSpec.Select(x => x.MapClientToServer()).ToList();

                productModelService.SaveProductModel(contactResp);
                TempData["message"] = new MessageViewModel
                {
                    IsSaved = true,
                    Message = "Your data has been saved successfully!"
                };
                if (string.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                    return RedirectToAction("ModelSpecs", new { product = viewModel.ProductModel.ProductId });
                return Redirect(Request.QueryString["returnUrl"]);
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }
        }
        
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        
        // POST: /Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
