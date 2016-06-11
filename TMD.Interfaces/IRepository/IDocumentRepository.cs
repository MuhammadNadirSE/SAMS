using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IDocumentRepository : IBaseRepository<Document, long>
    {
        IEnumerable<Document> GetAllDocumentByRefId(int id, int type);
    }
}
