using DellyShopApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShopApp.Models {
    public class Product : BaseVm {
        [JsonProperty( "id" )]
        public long Id { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "image" )]
        public string Image { get; set; }

        [JsonProperty( "price" )]
        public decimal Price { get; set; }

        [JsonProperty( "DailyQty7Days" )]
        public string DailyQty7Days { get; set; }

        [JsonProperty( "cat_code" )]
        public string CatCode { get; set; }

        [JsonProperty( "cat_name" )]
        public string CatName { get; set; }

        private int _count = 0;
        public int Count {
            get => _count;
            set {
                _count = value;
                OnPropertyChanged( nameof( Count ) );
            }
        }
    }
}
