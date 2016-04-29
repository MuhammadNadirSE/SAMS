using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Web.ViewModels.Contact;
using TMD.Web.ModelMappers;

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
            return View();
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

                
                // TODO: Add insert logic here
                if (ContactViewModel.Contact.ContactID > 0)
                {
                   
                    contactService.UpdateCategory(ContactViewModel.Contact.MapClientToServer());
                }
                else
                {
                    ContactViewModel.Contact.CreatedDate = DateTime.UtcNow;
                    ContactViewModel.Contact.CreatedBy = User.Identity.GetUserId();
               
                    contactService.AddCategory(ContactViewModel.Contact.MapClientToServer());
                }

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
