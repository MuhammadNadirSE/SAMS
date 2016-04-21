using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class LeaveRepository : BaseRepository<Leave>,ILeaveRepository
    {
        public LeaveRepository(IUnityContainer container) : base(container)
        {
        }

        protected override IDbSet<Leave> DbSet
        {
            get { return db.Leaves; }
        }
    }
}
