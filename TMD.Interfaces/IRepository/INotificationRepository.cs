using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface INotificationRepository : IBaseRepository<Notification, long>
    {
        //IEnumerable<Notification> GetAllNotificationsByUserId(string userId);
        int GetUnreadNotificationsCount(string userId);
    }
}
