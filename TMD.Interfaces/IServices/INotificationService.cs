using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface INotificationService
    {
        long AddNotification(Notification notification);
        IEnumerable<Notification> GetAllNotificationsByUserId(string userId);
        int GetUnreadNotificationsCount(string userId);
    }
}