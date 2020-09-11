using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShopApp.Models {
    public class Transection {

        [JsonProperty( "DTG" )]
        public DateTime DTG { get; set; }

        [JsonProperty( "id" )]
        public int Id { get; set; }

        [JsonProperty( "parent_id" )]
        public int ParentId { get; set; }

        [JsonProperty( "Ref" )]
        public string Ref { get; set; }

        [JsonProperty( "Credit" )]
        public decimal Credit { get; set; }

        [JsonProperty( "Debit" )]
        public decimal Debit { get; set; }

        [JsonProperty( "Balance" )]
        public decimal Balance { get; set; }

    }
}
