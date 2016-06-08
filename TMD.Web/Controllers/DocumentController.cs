using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMD.Interfaces.IServices;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IDocumentService documentService;

        public DocumentController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }
        
        public ActionResult Download(long id)
        {
            var doc = documentService.GetDocumentById(id);

            if (doc != null && doc.DocumentData != null)
            {
                //string ext = doc.DocumentType.Split('/')[1];
                return File(doc.DocumentData, doc.DocumentType, doc.DocumentName);
            }

            return File(new byte[] { }, "image/png", "null.png");
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                documentService.DeleteDocument(id);
            }
            catch (Exception e)
            {
                return Json(new { response = "Probably, record has already been deleted.", status = (int)HttpStatusCode.BadRequest }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { response = "Successfully deleted the record!", status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }
    }
}