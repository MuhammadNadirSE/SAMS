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
using System.Linq.Expressions;
using TMD.Models.Common;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Repository.Repositories
{
    public class InquiryRepository : BaseRepository<Inquiry>, IInquiryRepository
    {
        public InquiryRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<Inquiry> DbSet
        {
            get { return db.Inquiry; }
        }

        public Inquiry GetInquiryAndInquiryDetail(int inquiryid)
        {
            return DbSet.Include(x => x.InquiryDetails).FirstOrDefault(x => x.InquiryID.Equals(inquiryid));
        }

        private readonly Dictionary<OrderByColumnInquiry, Func<Inquiry, object>> sortClause =

         new Dictionary<OrderByColumnInquiry, Func<Inquiry, object>>
            {
                {OrderByColumnInquiry.ContactName, c => c.ContactID},
                {OrderByColumnInquiry.Priority, c => c.Priority},
                {OrderByColumnInquiry.CreatedBy, c => c.CreatedByUser.FirstName}
            };
        public InquiryResponse GetAllInquiries(InquirySearchRequest searchRequest)
        {
            int fromRow = (searchRequest.PageNo - 1) * searchRequest.PageSize;
            int toRow = searchRequest.PageSize;

            Expression<Func<Inquiry, bool>> query =
                s =>
                    (
                    (string.IsNullOrEmpty(searchRequest.ContactName) || (s.Contact.FirstName + " " + s.Contact.LastName).Contains(searchRequest.ContactName)) &&
                    (searchRequest.Priority==0 || (s.Priority) == searchRequest.Priority) &&
                    (string.IsNullOrEmpty(searchRequest.CreatedBy) || (s.CreatedByUser.FirstName + " " + s.CreatedByUser.LastName).Contains(searchRequest.CreatedBy))
                    );

            IEnumerable<Inquiry> inquiries = searchRequest.IsAsc
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
            return new InquiryResponse { Inquiries = inquiries.ToList(), TotalCount = DbSet.Count(query), FilteredCount = inquiries.Count() };
        }

    }
}
