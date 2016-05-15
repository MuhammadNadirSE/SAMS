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
    public class InquiryDetailRepository : BaseRepository<InquiryDetail>, IInquiryDetailRepository
    {
        public InquiryDetailRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<InquiryDetail> DbSet
        {
            get { return db.InuiryDetail; }
        }

        public IEnumerable<InquiryDetail> GetInquiryDailByByInquiryId(int id)
        {
            return DbSet.Where(x => x.InquiryID == id);
        }
    }
}
