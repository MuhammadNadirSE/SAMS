
using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IDocumentService
    {
        int AddDocument(Document document);
        int UpdateDocument(Document document);
        bool DeleteDocument(int documentId);
        IEnumerable<Document> GetAllDocumentByRefID(int id);
       

    }
}
