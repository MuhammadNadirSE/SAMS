using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class EmployeeSupervisorRepository : BaseRepository<EmployeeSupervisor>, IEmployeeSupervisorRepository
    {
        public EmployeeSupervisorRepository(IUnityContainer container)
            : base(container)
        {
        }

        protected override IDbSet<EmployeeSupervisor> DbSet
        {
            get { return db.EmployeeSupervisor; }
        }


        public IEnumerable<EmployeeSupervisor> GetSupervisorsByEmployeeId(int id)
        {
            return DbSet.Select(x=>x).Where(x=>x.EmployeeId==id).ToList();
        }
    }
}
