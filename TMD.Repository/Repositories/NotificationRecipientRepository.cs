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
    public class NotificationRecipientRepository : BaseRepository<NotificationRecipient>,INotificationRecipientRepository
    {
        public NotificationRecipientRepository(IUnityContainer container) : base(container)
        {
        }
        protected override IDbSet<NotificationRecipient> DbSet => db.NotificationRecipient;
    }
}
