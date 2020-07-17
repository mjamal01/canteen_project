using System;
namespace DellyShopApp.Models
{
    public class userinfo_mobile_v
    {
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string StoreName { get; set; }
        public string GroupName { get; set; }
        public string parent_name { get; set; }
        public int UserId { get; set; }
        public int created_on { get; set; }
        public DateTime created_on_dateTime { get; set; }
        public int group_id { get; set; }
        public int store_id { get; set; }
        public int parent_id { get; set; }
        public bool active { get; set; }
    }
}
