
using System.Collections.Generic;
using TMD.Common;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IDocumentService
    {
        int AddDocuments(List<Document> documents,int refrenceId, DocumentType refrenceType);
        bool DeleteDocument(int documentId);
        IEnumerable<Document> GetAllDocumentByRefID(int id);
        Document GetDocumentById(long id);
    }
}
