using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class DesignationRepository : BaseRepository<Designation>, IDesignationRepository
    {
        public DesignationRepository(IUnityContainer container)
            : base(container)
        {
        }

        protected override IDbSet<Designation> DbSet
        {
            get { return db.Designation; }
        }

      
        
   
   

    }
}
