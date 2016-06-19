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
            //return DbSet.Include("NotificationRecipients").Select(n => new { notification= n,r=n.NotificationRecipients.Where(y => y.UserId.Equals(userId))}).AsEnumerable().Select(x=>x.notification);
            return DbSet.Include("NotificationRecipients").Where(x => x.NotificationRecipients.Any(y => y.UserId.Equals(userId))).ToList();
        }
    }
}
