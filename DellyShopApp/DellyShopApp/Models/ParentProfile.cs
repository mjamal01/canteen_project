using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShopApp.Models {
    public class ParentProfile {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "address" )]
        public string Address { get; set; }

        [JsonProperty( "phone" )]
        public string Phone { get; set; }

        [JsonProperty( "email" )]
        public string Email { get; set; }

        [JsonProperty( "id" )]
        public long Id { get; set; }

        [JsonProperty( "NationalIqamaId" )]
        public string NationalIqamaId { get; set; }
    }
}
