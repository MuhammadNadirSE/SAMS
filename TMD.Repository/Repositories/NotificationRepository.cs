using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>,INotificationRepository
    {
        public NotificationRepository(IUnityContainer container) : base(container)
        {
        }
        
        protected override IDbSet<Notification> DbSet
        {
            get { return db.Notification; }
        }
        
        public IEnumerable<Notification> Get30DaysNotificationsByUserId(string userId)
        {
            return DbSet.Include(x => x.NotificationRecipients.Where(y => y.UserId.Equals(userId)));
        }
    }
}
