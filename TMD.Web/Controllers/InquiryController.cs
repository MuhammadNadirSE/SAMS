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
    public class InquiryController : BaseController
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
            string[] userPermissionsSet = (string[])Session["UserPermissionSet"];
            searchRequest.HasPermissionToViewAll = userPermissionsSet.Contains("ViewAllInquiries");
            searchRequest.CurrentUserId = User.Identity.GetUserId();

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
            InquiryViewModel inquiryViewModel = new InquiryViewModel
            {
                InquiryModel = new Models.InquiryModel { InquiryDate = DateTime.UtcNow}
            };
            
                var inquiryResponse = inquiryService.GetInquiryResponse(ID);
                if (inquiryResponse.Inquiry != null)
                {
                    inquiryViewModel.InquiryModel = inquiryResponse.Inquiry.MapServerToClient();
                    inquiryViewModel.InquiryModel.InquiryProductId = inquiryResponse.InquiryDetails.FirstOrDefault().ProductID;
                    inquiryViewModel.Documents = inquiryResponse.InquiryDocuments.ToList();
                }

            inquiryViewModel.Contacts = inquiryResponse.Contacts.Select(x => x.CreateDDL()).ToList();
            inquiryViewModel.Products = inquiryResponse.Products.Select(x => x.MapServerToClient()).ToList();
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(inquiryViewModel);
        }

        [SiteAuthorize(PermissionKey = "CreateUpdateInquiry")]
        [HttpPost]
        public ActionResult Create(InquiryViewModel inquiryViewModel )
        {
            try
            {
                inquiryViewModel.InquiryModel.UpdateDate = DateTime.UtcNow;
                inquiryViewModel.InquiryModel.UpdatedBy = User.Identity.GetUserId();
                if (inquiryViewModel.InquiryModel.InquiryID == 0)
                {
                    inquiryViewModel.InquiryModel.CreatedDate = DateTime.UtcNow;
                    inquiryViewModel.InquiryModel.CreatedBy = User.Identity.GetUserId();
                    inquiryViewModel.InquiryModel.UserId = User.Identity.GetUserId();
                }

                InquiryResponse inquiryResp = new InquiryResponse();
                
                inquiryResp.Inquiry = inquiryViewModel.InquiryModel.MapClientToServer();
                //if (inquiryViewModel.InquiryDetail != null)
                inquiryResp.InquiryDetails = new List<InquiryDetail>
                    {
                        new InquiryDetail
                        {
                            ProductID = inquiryViewModel.InquiryModel.InquiryProductId
                        }
                    };
                //upload files data
                if (inquiryViewModel.UploadFiles.Any())
                {
                    foreach (var file in inquiryViewModel.UploadFiles)
                    {
                        if (file != null)
                        {
                            var tempStream = file.InputStream;
                            byte[] bytes = new byte[tempStream.Length];
                            tempStream.Read(bytes, 0, Convert.ToInt32(tempStream.Length));
                            Document document = new Document
                            {
                                DocumentData = bytes,
                                DocumentName = file.FileName,
                                DocumentType = file.ContentType
                            };
                            inquiryResp.InquiryDocuments.Add(document);
                        }
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
    }
}
