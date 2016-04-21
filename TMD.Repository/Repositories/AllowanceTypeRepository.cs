using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class AllowanceTypeRepository : BaseRepository<AllowanceType>, IAllowanceTypeRepository
    {
        #region Constructor
        public AllowanceTypeRepository(IUnityContainer container)
            : base(container)
        {
        }

        protected override IDbSet<AllowanceType> DbSet
        {
            get { return db.AllowanceTypes; }
        }
        #endregion

        #region Private
        #endregion

        #region Public
        #endregion
    }
}
