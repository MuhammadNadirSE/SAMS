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
using TMD.Models.Common;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using System.Linq.Expressions;

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

        private readonly Dictionary<OrderByColumnQuote, Func<Quote, object>> sortClause =

         new Dictionary<OrderByColumnQuote, Func<Quote, object>>
            {
                {OrderByColumnQuote.Subject, c => c.Subject},
                {OrderByColumnQuote.ReferenceNumber, c => c.QuoteID},
                {OrderByColumnQuote.ContactName, c => c.Contact.FirstName},
                
            };
        public QuoteResponse GetAllQuotes(QuoteSearchRequest searchRequest)
        {
            int fromRow = (searchRequest.PageNo - 1) * searchRequest.PageSize;
            int toRow = searchRequest.PageSize;

            Expression<Func<Quote, bool>> query =
                s => searchRequest.HasPermissionToViewAll ?
                    (
                        (string.IsNullOrEmpty(searchRequest.Subject) || (s.Subject).Contains(searchRequest.Subject)) &&
                        (string.IsNullOrEmpty(searchRequest.ReferenceNumber) || (s.QuoteReferenceNo).Contains(searchRequest.ReferenceNumber)) 
                   
                    ): (
                        (string.IsNullOrEmpty(searchRequest.Subject) || (s.Subject).Contains(searchRequest.Subject)) &&
                        ((s.CreatedBy).Equals(searchRequest.CurrentUserId)) &&
                        (string.IsNullOrEmpty(searchRequest.ReferenceNumber) || (s.QuoteReferenceNo).Contains(searchRequest.ReferenceNumber))

                    );

            IEnumerable<Quote> quotes = searchRequest.IsAsc
               ? DbSet
                   .Where(query)
                   .OrderBy(sortClause[searchRequest.OrderByColumn]).Skip(fromRow)
                   .Take(toRow)
                   .ToList()
               : DbSet
                   .Where(query)
                   .OrderByDescending(sortClause[searchRequest.OrderByColumn]).Skip(fromRow)
                   .Take(toRow)
                   .ToList();
            return new QuoteResponse { Quotes = quotes.ToList(), TotalCount = DbSet.Count(query), FilteredCount = quotes.Count() };
        }
    }
}
