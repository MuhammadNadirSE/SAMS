using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;


namespace TMD.Repository.Repositories
{
    public class TechnicalSpecsRepository : BaseRepository<TechnicalSpec>,ITechnicalSpecsRepository
    {
        public TechnicalSpecsRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<TechnicalSpec> DbSet
        {
            get { return db.TechnicalSpec; }
        }
       
    }
}
