using System;
using System.Linq;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using Angle.ModelMappers;
using Angle.ViewModels.Common;
using Angle.ViewModels.ServiceProvider;

namespace Angle.Controllers
{
    [Authorize]
    public class ServiceProviderController : Controller
    {
        //User in the Application as Service Provider

        #region Private

        private readonly IDistributorService distributorService;

        #endregion

        #region Constructor

        public ServiceProviderController(IDistributorService distributorService)
        {
            this.distributorService = distributorService;
        }

        #endregion

        #region Public

        public ActionResult Index()
        {
            ServiceProviderListViewModel viewModel = new ServiceProviderListViewModel
            {
                Distributors = distributorService.GetAll().Select(x => x.CreateFromServerToClient()).ToList()
            };
            return View(viewModel);
        }


        public ActionResult AddEdit(int? id)
        {
            ServiceProviderViewModel viewModel = new ServiceProviderViewModel();
            if (id != null)
            {
                viewModel.Distributor = distributorService.FindDistributorById((int) id).CreateFromServerToClient();
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddEdit(ServiceProviderViewModel viewModel)
        {
            try
            {
                if (viewModel.Distributor.DistributorId > 0)
                {
                    var spToSave = viewModel.Distributor.CreateFromClientToServer();
                    if (distributorService.UpdateDistributor(spToSave))
                    {
                        TempData["message"] = new MessageViewModel
                        {
                            Message = "Record has been Updated",
                            IsUpdated = true
                        };
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    var spToSave = viewModel.Distributor.CreateFromClientToServer();
                    if (distributorService.SaveDistributor(spToSave))
                    {
                        TempData["message"] = new MessageViewModel
                        {
                            Message = "Record has been Saved",
                            IsSaved = true
                        };
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (Exception e)
            {
                TempData["message"] = new MessageViewModel {Message = e.Message, IsError = true};
                return RedirectToAction("AddEdit", e);
            }
            return View(viewModel);
        }

        #endregion
    }
}