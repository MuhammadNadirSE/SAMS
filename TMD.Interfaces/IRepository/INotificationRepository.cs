using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface INotificationRepository : IBaseRepository<Notification, long>
    {
        IEnumerable<Notification> Get30DaysNotificationsByUserId(string userId);
    }
}
