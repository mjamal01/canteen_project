using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShopApp.Models { 
    public class School {
        [JsonProperty( "school_id" )]
        public int SchoolId { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }
    }
}
