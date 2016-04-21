using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnityContainer container)
            : base(container)
        {
        }

        protected override IDbSet<Employee> DbSet
        {
            get { return db.Employee; }
        }
    }
}
