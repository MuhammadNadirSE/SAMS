using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.Common;
using TMD.Web.ViewModels.Product;

namespace TMD.Web.Controllers
{
    public class TechnicalSpecsController : Controller
    {
        private readonly ITechnicalSpecsService technicalSpecsService;
        public TechnicalSpecsController(ITechnicalSpecsService technicalSpecsService)
        {
            this.technicalSpecsService = technicalSpecsService;
        }
        //
        // GET: /TechnicalSpecs/
        public ActionResult Index()
        {
            List<TMD.Web.Models.TechnicalSpecsModel> TechnicalSpecs =
               technicalSpecsService.GetAllTechnicalSpecs()
                   .ToList()
                   .Select(x => x.MapServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(TechnicalSpecs);
        }

        //
        // GET: /TechnicalSpecs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TechnicalSpecs/Create
        public ActionResult Create(int ?id)
        {
            TechnicalSpecsViewModel technicalSpecsView = new TechnicalSpecsViewModel();
            TMD.Models.DomainModels.TechnicalSpec techSpec = null;

            if (id !=null)
                techSpec = technicalSpecsService.GetPTechnicalSpecsById(Convert.ToInt32(id));

            if (techSpec != null)
            {
                technicalSpecsView.TechnicalSpec = techSpec.MapServerToClient();
            }
            else
            {
                technicalSpecsView.TechnicalSpec = new Models.TechnicalSpecsModel();
            }

            technicalSpecsView.TechnicalSpecs = technicalSpecsService.GetAllTechnicalSpecs().Select(x => x.MapServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(technicalSpecsView);
        }

        //
        // POST: /TechnicalSpecs/Create
        [HttpPost]
        public ActionResult Create(TechnicalSpecsViewModel technicalSpecsViewModel)
        {
            try
            {
                technicalSpecsViewModel.TechnicalSpec.UpdatedDate = DateTime.UtcNow;
                technicalSpecsViewModel.TechnicalSpec.UpdatedBy = User.Identity.GetUserId();
                // TODO: Add insert logic here
                if (technicalSpecsViewModel.TechnicalSpec.TechnicalSpecId > 0)
                {
                    technicalSpecsService.UpdateTechnicalSpecs(technicalSpecsViewModel.TechnicalSpec.MapClientToServer());
                }
                else
                {
                    technicalSpecsViewModel.TechnicalSpec.CreatedDate = DateTime.UtcNow;
                    technicalSpecsViewModel.TechnicalSpec.CreatedBy = User.Identity.GetUserId();

                    technicalSpecsService.AddTechnicalSpecs(technicalSpecsViewModel.TechnicalSpec.MapClientToServer());
                }
                TempData["message"] = new MessageViewModel
                {
                    IsSaved = true,
                    Message = "Your data has been saved successfully!"
                };
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /TechnicalSpecs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TechnicalSpecs/Edit/5
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
        // GET: /TechnicalSpecs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TechnicalSpecs/Delete/5
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
