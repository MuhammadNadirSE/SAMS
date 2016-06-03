using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels.Common;
using TMD.Web.ViewModels.Inquiry;
using TMD.WebBase.Mvc;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class InquiryController : Controller
    {

        private readonly IInquiryService inquiryService;
        private readonly IDocumentService documentService;

        public InquiryController(IInquiryService inquiryService, IDocumentService documentService)
        {
            this.inquiryService = inquiryService;
            this.documentService = documentService;
        }

        [SiteAuthorize(PermissionKey = "InquiriesList")]
        public ActionResult Index()
        {
            //List<TMD.Web.Models.InquiryModel> Inquiries =
            //    inquiryService.GetAllInquiries()
            //        .ToList()
            //        .Select(x => x.MapServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(new InquiryViewModel());
        }

        [HttpPost]
        public JsonResult Index(InquirySearchRequest searchRequest)
        {

            var contactResponse = inquiryService.GetAllInquiries(searchRequest);
            var inquiryList = contactResponse.Inquiries.ToList().Select(x => x.MapServerToClientSearch()).ToList();
            var model = new InquiryViewModel()
            {
                data = inquiryList,
                recordsFiltered = contactResponse.FilteredCount,
                recordsTotal = contactResponse.TotalCount
            };
            //var obj = new {data = model.EmployeePayrolls, model};
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
        [SiteAuthorize(PermissionKey = "CreateUpdateInquiry")]
        public ActionResult Create(int? ID)
        {
            InquiryViewModel InquiryViewModel = new InquiryViewModel
            {
                InquiryModel = new Models.InquiryModel { InquiryDate = DateTime.UtcNow}
            };
            
                var inquiryResponse = inquiryService.GetInquiryResponse(ID);
                if (inquiryResponse.Inquiry != null)
                {
                    InquiryViewModel.InquiryModel = inquiryResponse.Inquiry.MapServerToClient();
                    InquiryViewModel.InquiryModel.InquiryProductId = inquiryResponse.InquiryDetails.FirstOrDefault().ProductID;
                }

                InquiryViewModel.Contacts = inquiryResponse.Contacts.Select(x => x.CreateDDL()).ToList();
                InquiryViewModel.Products = inquiryResponse.Products.Select(x => x.MapServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(InquiryViewModel);


        }

        [SiteAuthorize(PermissionKey = "CreateUpdateInquiry")]
        [HttpPost]
        public ActionResult Create(InquiryViewModel ContactViewModel )
        {
            try
            {
                ContactViewModel.InquiryModel.UpdateDate = DateTime.UtcNow;
                ContactViewModel.InquiryModel.UpdatedBy = User.Identity.GetUserId();
                if (ContactViewModel.InquiryModel.InquiryID == 0)
                {
                    ContactViewModel.InquiryModel.CreatedDate = DateTime.UtcNow;
                    ContactViewModel.InquiryModel.CreatedBy = User.Identity.GetUserId();
                    ContactViewModel.InquiryModel.UserId = User.Identity.GetUserId();
                }

                InquiryResponse inquiryResp = new InquiryResponse();
                
                inquiryResp.Inquiry = ContactViewModel.InquiryModel.MapClientToServer();
                //if (ContactViewModel.InquiryDetail != null)
                inquiryResp.InquiryDetails = new List<InquiryDetail>
                    {
                        new InquiryDetail
                        {
                            ProductID = ContactViewModel.InquiryModel.InquiryProductId
                        }
                    };
                //upload files data
                if (ContactViewModel.UploadFiles.Any())
                {
                    foreach (var file in ContactViewModel.UploadFiles)
                    {
                        var tempStream = file.InputStream;
                        byte[] bytes = new byte[tempStream.Length];
                        tempStream.Read(bytes, 0, Convert.ToInt32(tempStream.Length));
                        Document document = new Document
                        {
                            DocumentData = bytes
                        };
                        inquiryResp.InquiryDocuments.Add(document);
                    }
                    
                }
                if (inquiryService.SaveInquiry(inquiryResp))
                {
                    TempData["message"] = new MessageViewModel
                    {
                        IsSaved = true,
                        Message = "Your data has been saved successfully!"
                    };
                }
                else
                {
                    TempData["message"] = new MessageViewModel
                    {
                        IsError = true,
                        Message = "There is some problem, please try again!"
                    };
                }
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
        #region User Activity Image
        [AllowAnonymous]
        public ActionResult Document(long id)
        {
            var image = documentService.GetDocumentById(id);
            
            if (image != null && image.DocumentData != null)
            {
                //string ext = image.ContentType.Split('/')[1];
                //return File(image.ImageData, image.ContentType, "IMG_" + image.Id + ((DateTime)image.UpdatedDate).ToString("yyyyMMdd_HHmmss") + "." + ext);
            }

            return File(new byte[] { }, "image/png", "null.png");
        }
        #endregion
    }
}
