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

      //  protected override IDbSet<Notification> DbSet => db.Notification;

        protected override IDbSet<Notification> DbSet
        {
            get { return db.Notification; }
        }
        
        public int GetUnreadNotificationsCount(string userId)
        {
            var today = DateTime.UtcNow;

            Expression<Func<Notification, bool>> query = s => (((s.NotificationRecipients.FirstOrDefault(r => r.UserId == userId).IsRead == false))
                                     && (s.CreatedDate <= today));

            return DbSet.Count(query);
        }
    }
}
