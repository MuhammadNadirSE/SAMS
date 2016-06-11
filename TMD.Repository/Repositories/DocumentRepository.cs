using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Repository.BaseRepository;
using TMD.Models.DomainModels;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace TMD.Repository.Repositories
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<Document> DbSet
        {
            get { return db.Document; }
        }

        public IEnumerable<Document> GetAllDocumentByRefId(int id, int type)
        {
            return DbSet.Where(x => x.RefrenceId.Equals(id) && x.RefrenceType.Equals(type));
        }
    }
}
