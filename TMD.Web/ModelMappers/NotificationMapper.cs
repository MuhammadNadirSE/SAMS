using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;
using TMD.Web.Models;
using TMD.Web.ViewModels.Notification;

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
        public static NotificationModel MapServerToClient(this Notification source)
        {
            return new NotificationModel
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
    }
}