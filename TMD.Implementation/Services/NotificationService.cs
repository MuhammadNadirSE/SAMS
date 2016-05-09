using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }

        public long AddNotification(Notification notification)
        {
            notificationRepository.Add(notification);
            notificationRepository.SaveChanges();
            return notification.NotificationId;
        }

        public IEnumerable<Notification> GetAllNotificationsByUserId(string userId)
        {
            return notificationRepository.GetAll();
        }

        public int GetUnreadNotificationsCount(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
