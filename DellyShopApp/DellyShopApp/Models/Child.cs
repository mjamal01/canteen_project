using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShopApp.Models {
    public class Child {
        [JsonProperty( "name" )]
        public string Name { get; set; } = "";

        [JsonProperty( "phone" )]
        public string Phone { get; set; } = "";

        [JsonProperty( "UniqueRef" )]
        public string UniqueRef { get; set; }

        [JsonProperty( "email" )]
        public string Email { get; set; } = "";

        [JsonProperty( "parent_name" )]
        public string ParentName { get; set; } = "";

        [JsonProperty( "id" )]
        public int Id { get; set; }

        [JsonProperty( "school_id" )]
        public int SchoolId { get; set; }

        [JsonProperty( "type" )]
        public int Type { get; set; } = 1;

        [JsonProperty( "parent_id" )]
        public int ParentId { get; set; }

        [JsonProperty( "TotalBalance" )]
        public double TotalBalance { get; set; }

        [JsonProperty( "avatar" )]
        public string Avatar { get; set; }

        [JsonProperty( "address" )]
        public string Address { get; set; }
    }
}
