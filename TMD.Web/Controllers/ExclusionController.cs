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
using TMD.Web.Models;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class ExclusionController : Controller
    {
        private readonly IExclusionService exclusionService;

        public ExclusionController(IExclusionService exclusionService)
        {
            this.exclusionService = exclusionService;
        }
       // [SiteAuthorize(PermissionKey = "ExclusionsList")]
        public ActionResult Index()
        {
            List<TMD.Web.Models.ExclusionModel> exclusions =
               exclusionService.GetAllExclusions()
                   .ToList()
                   .Select(x => x.MapServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(exclusions);
        }

       // [SiteAuthorize(PermissionKey = "CreateUpdateTechSpec")]
        public ActionResult Create(int? id)
        {


            ExclusionModel exModel = new Models.ExclusionModel(); 

            if (id != null)
            {
                

                 var  exclusionModel = exclusionService.GetExclusionById(Convert.ToInt32(id));

                if (exclusionModel != null)
                {
                    exModel = exclusionModel.MapServerToClient();
                }
              
            }
           
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(exModel);
        }

      //  [SiteAuthorize(PermissionKey = "CreateUpdateTechSpec")]
        [HttpPost]
        public ActionResult Create(ExclusionModel exclusionModel)
        {
            try
            {
               exclusionModel.UpdatedDate = DateTime.UtcNow;
               exclusionModel.UpdatedBy = User.Identity.GetUserId();
                // TODO: Add insert logic here
                if (exclusionModel.ExclusionId > 0)
                {
                    exclusionService.UpdateExclusion(exclusionModel.MapClientToServer());
                }
                else
                {
                    exclusionModel.CreatedDate = DateTime.UtcNow;
                    exclusionModel.CreatedBy = User.Identity.GetUserId();

                    exclusionService.AddExclusion(exclusionModel.MapClientToServer());
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
