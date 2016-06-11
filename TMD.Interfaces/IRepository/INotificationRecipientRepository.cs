using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface INotificationRecipientRepository : IBaseRepository<NotificationRecipient, long>
    {
        int GetUnreadNotificationsCount(string userId);
    }
}
