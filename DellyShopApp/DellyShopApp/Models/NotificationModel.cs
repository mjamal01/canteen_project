using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShopApp.Models
{
   public class NotificationModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime InstertedAt { get; set; }
    }
}
