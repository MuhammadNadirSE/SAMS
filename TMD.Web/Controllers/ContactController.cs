using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.ResponseModels;
using TMD.Web.ViewModels.Contact;
using TMD.Web.ModelMappers;
using TMD.Models.RequestModels;

namespace TMD.Web.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        //
        // GET: /Contact/
        public ActionResult Index()
        {
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

        //
        // GET: /Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Contact/Create
        public ActionResult Create(int? id)
        {
            ContactViewModel contactViewModel = new ContactViewModel();

             contactViewModel.Contact = new Models.ContactModel();
            if (id != null)
            {
                var contact = contactService.GetContactById((int)id);
                if (contact != null)
                    contactViewModel.Contact = contact.MapServerToClient();
            }
                

             return View(contactViewModel);
        }

        //d
        // POST: /Contact/Create
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

                contactService.SaveContact(contactResp);

                return RedirectToAction("Create");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Contact/Edit/5
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
        // GET: /Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Contact/Delete/5
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
