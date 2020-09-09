using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShopApp.Models {
    public class UserInfo {

        [JsonProperty( "username" )]
        public string Username { get; set; }

        [JsonProperty( "first_name" )]
        public string FirstName { get; set; }

        [JsonProperty( "first_name_ar" )]
        public string FirstNameAr { get; set; }

        [JsonProperty( "last_name" )]
        public string LastName { get; set; }

        [JsonProperty( "last_name_ar" )]
        public string LastNameAr { get; set; }

        [JsonProperty( "StoreName" )]
        public string StoreName { get; set; }

        [JsonProperty( "StoreName_ar" )]
        public string StoreNameAr { get; set; }

        [JsonProperty( "GroupName" )]
        public string GroupName { get; set; }

        [JsonProperty( "GroupName_ar" )]
        public string GroupNameAr { get; set; }

        [JsonProperty( "parent_name" )]
        public string ParentName { get; set; }

        [JsonProperty( "parent_name_ar" )]
        public string ParentNameAr { get; set; }

        [JsonProperty( "UserId" )]
        public int UserId { get; set; }

        [JsonProperty( "created_on" )]
        public int CreatedOn { get; set; }

        [JsonProperty( "created_on_dateTime" )]
        public DateTime CreatedOnDateTime { get; set; }

        [JsonProperty( "group_id" )]
        public int GroupId { get; set; }

        [JsonProperty( "store_id" )]
        public int StoreId { get; set; }

        [JsonProperty( "parent_id" )]
        public int ParentId { get; set; }

        [JsonProperty( "active" )]
        public bool Active { get; set; }

    }
}
