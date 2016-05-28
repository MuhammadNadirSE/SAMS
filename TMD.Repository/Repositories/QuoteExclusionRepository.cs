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
    public class QuoteExclusionRepository : BaseRepository<QuoteExclusion>, IQuoteExclusionRepository
    {
        public QuoteExclusionRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<QuoteExclusion> DbSet
        {
            get { return db.QuoteExclusion; }
        }

    }
}
