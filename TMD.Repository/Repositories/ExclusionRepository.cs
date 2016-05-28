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
    public class ExclusionRepository : BaseRepository<Exclusion>, IExclusionRepository
    {
        public ExclusionRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<Exclusion> DbSet
        {
            get { return db.Exclusion; }
        }

    }
}
