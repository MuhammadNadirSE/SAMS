using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Common;
using TMD.Interfaces.IServices;
using TMD.Models.ResponseModels;
using TMD.Web.ViewModels.Contact;
using TMD.Web.ModelMappers;
using TMD.Models.RequestModels;
using TMD.Web.ViewModels.Common;
using TMD.WebBase.Mvc;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class ContactController : BaseController
    {

        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        [SiteAuthorize(PermissionKey = "ContactsList")]
        public ActionResult Index()
        {
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(new ContactViewModel());
        }

        [HttpPost]
        public JsonResult Index(ContactSearchRequest searchRequest)
        {
           
            var contactResponse = contactService.GetAllContacts(searchRequest);
            var contactList = contactResponse.Contacts.ToList().Select(x => x.MapServerToClient()).ToList();
            var model = new ContactViewModel
            {
                data = contactList,
                recordsFiltered = contactResponse.FilteredCount,
                recordsTotal = contactResponse.TotalCount
            };
            //var obj = new {data = model.EmployeePayrolls, model};
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [SiteAuthorize(PermissionKey = "CreateUpdateContact")]
        public ActionResult Create(int? id)
        {
            ContactViewModel contactViewModel = new ContactViewModel
            {
                Contact = new Models.ContactModel()
            };

            if (id != null)
            {
                var contact = contactService.GetContactAndAddresses((int)id);
                if (contact != null)
                {
                    contactViewModel.Contact = contact.MapServerToClient();
                    contactViewModel.Addresses = contact.Addresses.ToList().Select(x=>x.MapServerToClient()).ToList();
                }
                    
            }
            ViewBag.ReturnUrl = Request.QueryString["returnUrl"];
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(contactViewModel);
        }

        [SiteAuthorize(PermissionKey = "CreateUpdateContact")]
        [HttpPost]
        public ActionResult Create(ContactViewModel ContactViewModel)
        {
            try
            {
                ContactViewModel.Contact.UpdateDate = DateTime.UtcNow;
                ContactViewModel.Contact.UpdatedBy = User.Identity.GetUserId();
                if (ContactViewModel.Contact.ContactID == 0)
                {
                    ContactViewModel.Contact.CreatedDate = DateTime.UtcNow;
                    ContactViewModel.Contact.CreatedBy = User.Identity.GetUserId();
                }


                ContactResponse contactResp=new ContactResponse();

             
                contactResp.Contact = ContactViewModel.Contact.MapClientToServer();
                if (ContactViewModel.Addresses != null)
                    contactResp.Addresses = ContactViewModel.Addresses.Select(x => x.MapClientToServer()).ToList();
                if (contactResp.Addresses.Any() && contactResp.Addresses.All(x => (AddressType) x.AddressType != AddressType.PrimaryAddress))
                {
                    contactResp.Addresses.FirstOrDefault().AddressType=(int)AddressType.PrimaryAddress;
                }
                contactService.SaveContact(contactResp);
                TempData["message"] = new MessageViewModel
                {
                    IsSaved = true,
                    Message = "Your data has been saved successfully!"
                };
                if (string.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                    return RedirectToAction("Create");
                return Redirect(Request.QueryString["returnUrl"]);
            }
            catch(Exception e)
            {
                return View();
            }
        }
    }
}
