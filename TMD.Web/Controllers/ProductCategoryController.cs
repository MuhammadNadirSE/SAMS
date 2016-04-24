using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.Models;
using TMD.Web.ViewModels.ProductCategory;
using TMD.Web.ModelMappers;

namespace TMD.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService productCategoryService { get; set; }
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }
        //
        // GET: /ProductCategory/
        public ActionResult Index()
        {
            return View();
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
           
                var prodCatResp=productCategoryService.GetProductCategoryResponse((int)id);
                if (prodCatResp.ProductCategory != null)
                {
                    productCategoryViewModel.ProductCategory = prodCatResp.ProductCategory.MapServerToClient();
                }

                productCategoryViewModel.ProductCategories = prodCatResp.ProductCategories.Select(x => x.MapServerToClient()).ToList();

                return View(productCategoryViewModel);
        }

        //
        // POST: /ProductCategory/Create
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

        //
        // GET: /ProductCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ProductCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ProductCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ProductCategory/Delete/5
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
