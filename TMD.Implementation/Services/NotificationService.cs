using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository notificationRepository;
        private readonly INotificationRecipientRepository notificationRecipientRepository;

        public NotificationService(INotificationRepository notificationRepository, INotificationRecipientRepository notificationRecipientRepository)
        {
            this.notificationRepository = notificationRepository;
            this.notificationRecipientRepository = notificationRecipientRepository;
        }

        public long AddNotification(Notification notification)
        {
            notificationRepository.Add(notification);
            notificationRepository.SaveChanges();
            return notification.NotificationId;
        }

        public IEnumerable<Notification> Get30DaysNotificationsByUserId(string userId)
        {
            return notificationRepository.Get30DaysNotificationsByUserId(userId);
        }

        public int GetUnreadNotificationsCount(string userId)
        {
            return notificationRecipientRepository.GetUnreadNotificationsCount(userId);
        }
    }
}
