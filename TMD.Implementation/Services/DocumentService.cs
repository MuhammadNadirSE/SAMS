using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Common;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public int AddDocuments(List<Document> documents, int refrenceId, DocumentType refrenceType)
        {
            foreach (var document in documents)
            {
                document.RefrenceId = refrenceId;
                document.RefrenceType = (int) refrenceType;
                documentRepository.Add(document);
            }
            documentRepository.SaveChanges();
            return 1;
        }
        public int AddDocument(Document document, int refrenceId, DocumentType refrenceType)
        {
            var doc = documentRepository.Find(document.DocumentId);
            if (doc != null)
            {
                //update photo content
                document.RefrenceType = (int)refrenceType;
                document.RefrenceId = refrenceId;
                doc.DocumentType = document.DocumentType;
                doc.DocumentData = document.DocumentData;
                documentRepository.Update(doc);
            }
            else
            {
                document.RefrenceType = (int)refrenceType;
                document.RefrenceId = refrenceId;
                documentRepository.Add(document);
            }
            documentRepository.SaveChanges();
            return 1;
        }
        public bool DeleteDocument(long documentId)
        {
            var doc = documentRepository.Find(documentId);

            if (doc == null) return false;

            documentRepository.Delete(doc);
            documentRepository.SaveChanges();
            return true;
        }
        public Document GetDocumentById(long id)
        {
            return documentRepository.Find(id);
        }
        public IEnumerable<Document> GetAllDocumentByRefId(int id, int type)
        {
            return documentRepository.GetAllDocumentByRefId(id,type);
        }
    }
}
