using System;
using System.Linq;
using System.Web.Mvc;
using Angle.ViewModels.Client;
using TMD.Interfaces.IServices;
using Angle.ModelMappers;
using Angle.ViewModels.Common;

namespace Angle.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {

        #region Private

        private readonly IClientService clientService;
        private readonly IDistributorService distributorService;

        #endregion

        #region Constructor

        public ClientController(IClientService clientService, IDistributorService distributorService)
        {
            this.clientService = clientService;
            this.distributorService = distributorService;
        }

        #endregion

        #region Public

        public ActionResult Index()
        {
            ClientListViewModel viewModel = new ClientListViewModel
            {
                Clients = clientService.GetAll().Select(x => x.CreateFromServerToClient()).ToList()
            };
            return View(viewModel);
        }

        public ActionResult AddEdit(int? id)
        {
            ClientViewModel viewModel = new ClientViewModel();
            if (id != null)
            {
                viewModel.Client = clientService.FindClientById((int) id).CreateFromServerToClient();
            }
            viewModel.Distributors = distributorService.GetAll().ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddEdit(ClientViewModel viewModel)
        {
            try
            {
                if (viewModel.Client.ClientId > 0)
                {
                    var clientToSave = viewModel.Client.CreateFromClientToServer();
                    if (clientService.UpdateClient(clientToSave))
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
                    var clientToSave = viewModel.Client.CreateFromClientToServer();
                    if (clientService.SaveClient(clientToSave))
                    {
                        TempData["message"] = new MessageViewModel {Message = "Record has been Saved", IsSaved = true};
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

        public ActionResult UploadData()
        {
            return View();
        }

        #endregion
    }
}