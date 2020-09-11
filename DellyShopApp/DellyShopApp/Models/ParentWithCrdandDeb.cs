using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShopApp.Models {
    public class ParentWithCrdandDeb: Parent {

        [JsonProperty( "TotalDebit" )]
        public decimal TotalDebit { get; set; }

        [JsonProperty( "TotalCredit" )]
        public decimal TotalCredit { get; set; }
    }
}
