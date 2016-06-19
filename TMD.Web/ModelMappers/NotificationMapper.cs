using System.Linq;
using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class NotificationMapper
    {
        public static Notification MapClientToServer(this NotificationModel source)
        {
            return new Notification
            {

                NotificationId = source.NotificationId,
                Title = source.Title,
                Description = source.Description,
                ActionPerformed = source.ActionPerformed,
                CategoryId = source.CategoryId,
                ItemId = source.ItemId,
                CreatedDate = source.CreatedDate,
                CreatedBy = source.CreatedBy


            };
        }
        public static NotificationModel MapServerToClient(this Notification source, string userId)
        {
            var recipient = source.NotificationRecipients.FirstOrDefault(x => x.UserId == userId);
            return new NotificationModel
            {
                NotificationId = source.NotificationId,
                Title = source.Title,
                Description = source.Description,
                ActionPerformed = source.ActionPerformed,
                CategoryId = source.CategoryId,
                ItemId = source.ItemId,
                CreatedDate = source.CreatedDate,
                CreatedBy = source.CreatedByUser.FirstName,
                isRead = recipient.IsRead?"Yes":"No",
                RecipientId = recipient.Id
            };
        }
    }
}