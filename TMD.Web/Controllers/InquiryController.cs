using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.ResponseModels;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels.Inquiry;

namespace TMD.Web.Controllers
{
    public class InquiryController : Controller
    {

        private readonly IInquiryService inquiryService;
        public InquiryController(IInquiryService inquiryService)
        {
            this.inquiryService = inquiryService;
        }
        //
        // GET: /Inquiry/
        public ActionResult Index()
        {
            List<TMD.Web.Models.InquiryModel> Inquiries =
                inquiryService.GetAllInquiries()
                    .ToList()
                    .Select(x => x.MapServerToClient()).ToList();

            return View(Inquiries);
        }

        //
        // GET: /Inquiry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Inquiry/Create
        public ActionResult Create(int? ID)
        {
        
           

            InquiryViewModel InquiryViewModel = new InquiryViewModel
            {
                InquiryModel = new Models.InquiryModel()
            };

           
            if (ID != null)
            {

                var inquiry = inquiryService.GetInquiryResponse((int)ID);
                if (inquiry != null)
                {
                    InquiryViewModel.InquiryModel = inquiry.Inquiry.MapServerToClient();
                    InquiryViewModel.InquiryDetail = inquiry.InquiryDetails.ToList().Select(x => x.MapServerToClient()).ToList();
                }

                InquiryViewModel.Contacts = inquiry.Contacts.Select(x => x.MapServerToClient()).ToList();
                InquiryViewModel.Products = inquiry.Products.Select(x => x.MapServerToClient()).ToList();

            }
          

           

            return View(InquiryViewModel);


        }

        //
        // POST: /Inquiry/Create
        [HttpPost]
        public ActionResult Create(InquiryViewModel ContactViewModel )
        {
            //try
            //{
            //    productViewModel.InquiryModel.UpdateDate = DateTime.UtcNow;
            //    productViewModel.InquiryModel.UpdatedBy = User.Identity.GetUserId();
            //    // TODO: Add insert logic here
            //    if (productViewModel.InquiryModel.InquiryID > 0)
            //    {
            //        inquiryService.UpdateInquiry(productViewModel.InquiryModel.MapClientToServer());
            //    }
            //    else
            //    {
            //        productViewModel.InquiryModel.CreatedDate = DateTime.UtcNow;
            //        productViewModel.InquiryModel.CreatedBy = User.Identity.GetUserId();

            //        inquiryService.AddInquiry(productViewModel.InquiryModel.MapClientToServer());
            //    }

            //    return RedirectToAction("Create");
            //}
            //catch (Exception ex)
            //{
            //    return View();
            //}

            try
            {
                ContactViewModel.InquiryModel.UpdateDate = DateTime.UtcNow;
                ContactViewModel.InquiryModel.UpdatedBy = User.Identity.GetUserId();
                if (ContactViewModel.InquiryModel.ContactID == 0)
                {
                    ContactViewModel.InquiryModel.CreatedDate = DateTime.UtcNow;
                    ContactViewModel.InquiryModel.CreatedBy = User.Identity.GetUserId();
                    ContactViewModel.InquiryModel.UserId = User.Identity.GetUserId();

                }


                InquiryResponse inquiryResp = new InquiryResponse();


                inquiryResp.Inquiry = ContactViewModel.InquiryModel.MapClientToServer();
                if (ContactViewModel.InquiryDetail != null)
                    inquiryResp.InquiryDetails = ContactViewModel.InquiryDetail.Select(x => x.MapClientToServer()).ToList();

                inquiryService.SaveInquiry(inquiryResp);

                return RedirectToAction("Create");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Inquiry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Inquiry/Edit/5
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
        // GET: /Inquiry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Inquiry/Delete/5
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
