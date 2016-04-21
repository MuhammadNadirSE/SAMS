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
    class TicketTypeRepository:BaseRepository<TicketType>, ITicketTypeRepository
    {
        public TicketTypeRepository(IUnityContainer container) : base(container)
        {
        }

        protected override IDbSet<TicketType> DbSet
        {
            get { return db.TicketTypes; }
        }

        public IEnumerable<TicketType> GetActiveTicketTypes()
        {
            return DbSet.Select(x => x).Where(x=>x.IsActive == true);
        }
    }
}
