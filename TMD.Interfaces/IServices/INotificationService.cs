using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface INotificationService
    {
        long AddNotification(Notification notification);
        IEnumerable<Notification> Get30DaysNotificationsByUserId(string userId);
        int GetUnreadNotificationsCount(string userId);
    }
}