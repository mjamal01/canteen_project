using DellyShopApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DellyShopApp.ViewModel {
    public class IndividualChildDetail {
        [JsonProperty( "customer_id" )]
        public long CustomerId { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "name_ar" )]
        public string NameAr { get; set; }

        [JsonProperty( "customer_image" )]
        public string CustomerImage { get; set; }

        [JsonProperty( "DailyCashLimit" )]
        public decimal DailyCashLimit { get; set; }

        [JsonProperty( "UniqueRef" )]
        public string UniqueRef { get; set; }

        [JsonProperty( "ProductsList" )]
        public ObservableCollection<productsWithQtyLimitMobile> ProductsList { get; set; } = new ObservableCollection<productsWithQtyLimitMobile>();
    }

    public class productsWithQtyLimitMobile : BaseVm {

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
