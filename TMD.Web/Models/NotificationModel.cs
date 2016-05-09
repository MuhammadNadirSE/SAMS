using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class NotificationModel
    {
        public long NotificationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ActionPerformed { get; set; }
        public int CategoryId { get; set; }
        public int ItemId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}