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
    public class QuoteDetailRepository : BaseRepository<QuoteDetail>, IQuoteDetailRepository
    {
        public QuoteDetailRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<QuoteDetail> DbSet
        {
            get { return db.QuoteDetail; }
        }

        public IEnumerable<QuoteDetail> GetQuoteDetailByQuoteId(int quoteId)
        {
            return DbSet.Where(x => x.QuoteId == quoteId);
        }
    }
}
