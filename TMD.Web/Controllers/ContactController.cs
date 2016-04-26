using System.Linq;
using System.Web.Mvc;
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
        public ActionResult Create(int id)
        {
            ContactViewModel contactViewModel = new ContactViewModel();

             contactViewModel.Contact = new Models.ContactModel();
            

           // ContactViewModel.ProductCategories = prodCatResp.ProductCategories.Select(x => x.MapServerToClient()).ToList();

             return View(contactViewModel);
        }

        //
        // POST: /Contact/Create
        [HttpPost]
        public ActionResult Create(ContactViewModel ContactViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ContactViewModel.Contact.ContactID > 0)
                {
                    contactService.UpdateCategory(ContactViewModel.Contact.MapClientToServer());
                }
                else
                {
                    contactService.AddCategory(ContactViewModel.Contact.MapClientToServer());
                }

                return RedirectToAction("Create");
            }
            catch
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
