using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TMD.Common;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository notificationRepository;
        private readonly INotificationRecipientRepository notificationRecipientRepository;
        private readonly IAspNetRoleRepository roleRepository;

        public NotificationService(INotificationRepository notificationRepository, INotificationRecipientRepository notificationRecipientRepository, IAspNetRoleRepository roleRepository)
        {
            this.notificationRepository = notificationRepository;
            this.notificationRecipientRepository = notificationRecipientRepository;
            this.roleRepository = roleRepository;
        }

        public long AddNotification(Notification notification)
        {
            //START: Add notification recipient
            notification.NotificationRecipients=new List<NotificationRecipient>();
            var roleIds = new List<string>();
            switch ((NotificationType)notification.CategoryId)
            {
                case NotificationType.Inquiry:
                    roleIds = new List<string>(ConfigurationManager.AppSettings["InquiryNotificationRoles"].Split(','));
                    break;
                case NotificationType.Quote:
                    roleIds = new List<string>(ConfigurationManager.AppSettings["QuoteNotificationRoles"].Split(','));
                    break;
            }
            var users = roleRepository.GetAllUsersOfRoles(roleIds);
            foreach (var user in users)
            {
                notification.NotificationRecipients.Add(new NotificationRecipient
                {
                    UserId = user.Id,
                    IsRead = false
                });
            }
            //END: Add notification recipient

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

        public bool MarkNotificationAsRead(long id)
        {
            var recipient=notificationRecipientRepository.Find(id);
            recipient.IsRead = true;
            notificationRecipientRepository.Update(recipient);
            notificationRecipientRepository.SaveChanges();
            return true;
        }
    }
}
