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
    public class DesignationController : BaseController
    {
        private readonly IDesignationService designationService;

        public DesignationController(IDesignationService designationService)
        {
            this.designationService = designationService;
        }
        [SiteAuthorize(PermissionKey = "DesignationsList")]
        public ActionResult Index()
        {
            List<TMD.Web.Models.DesignationModel> designations =
               designationService.GetAllDesignations()
                   .ToList()
                   .Select(x => x.MapServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(designations);
        }

        [SiteAuthorize(PermissionKey = "CreateUpdateDesignations")]
        public ActionResult Create(int? id)
        {


            DesignationModel exModel = new Models.DesignationModel();

            if (id != null)
            {


                var designationModel = designationService.GetDesignationById(Convert.ToInt32(id));

                if (designationModel != null)
                {
                    exModel = designationModel.MapServerToClient();
                }

            }

            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(exModel);
        }

        [SiteAuthorize(PermissionKey = "CreateUpdateDesignations")]
        [HttpPost]
        public ActionResult Create(DesignationModel designationModel)
        {
            try
            {
                designationModel.RecLastUpdatedDt = DateTime.UtcNow;
                designationModel.RecLastUpdatedBy = User.Identity.GetUserId();
                // TODO: Add insert logic here
                if (designationModel.DesignationId > 0)
                {
                    designationService.UpdateDesignation(designationModel.MapClientToServer());
                }
                else
                {
                    designationModel.RecCreatedDt = DateTime.UtcNow;
                    designationModel.RecCreatedBy = User.Identity.GetUserId();

                    designationService.AddDesignation(designationModel.MapClientToServer());
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
