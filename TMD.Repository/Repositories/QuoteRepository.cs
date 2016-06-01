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
    public class QuoteRepository : BaseRepository<Quote>, IQuoteRepository
    {
        public QuoteRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<Quote> DbSet
        {
            get { return db.Quote; }
        }

        public Quote GetQuoteAndQuoteDetail(int quoteId)
        {
            return DbSet.Include("QuoteDetails").Include("QuoteExclusions").FirstOrDefault(x => x.QuoteID == quoteId);
        }
    }
}
