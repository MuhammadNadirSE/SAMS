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
using TMD.WebBase.Mvc;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class TechnicalSpecsController : BaseController
    {
        private readonly ITechnicalSpecsService technicalSpecsService;
        public TechnicalSpecsController(ITechnicalSpecsService technicalSpecsService)
        {
            this.technicalSpecsService = technicalSpecsService;
        }
        [SiteAuthorize(PermissionKey = "TechnicalSpecsList")]
        public ActionResult Index()
        {
            List<TMD.Web.Models.TechnicalSpecsModel> TechnicalSpecs =
               technicalSpecsService.GetAllTechnicalSpecs()
                   .ToList()
                   .Select(x => x.MapServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(TechnicalSpecs);
        }
        
        [SiteAuthorize(PermissionKey = "CreateUpdateTechSpec")]
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

        [SiteAuthorize(PermissionKey = "CreateUpdateTechSpec")]
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
    }
}
