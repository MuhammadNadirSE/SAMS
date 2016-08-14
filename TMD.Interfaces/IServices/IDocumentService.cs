
using System.Collections.Generic;
using TMD.Common;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IDocumentService
    {
        int AddDocuments(List<Document> documents,int refrenceId, DocumentType refrenceType);
        int AddDocument(Document document,int refrenceId, DocumentType refrenceType);
        bool DeleteDocument(long documentId);
        IEnumerable<Document> GetAllDocumentByRefId(int id, int type);
        Document GetDocumentById(long id);
    }
}
