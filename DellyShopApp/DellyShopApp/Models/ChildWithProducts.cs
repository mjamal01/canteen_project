using DellyShopApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DellyShopApp.Models {
    public class ChildWithProducts : Child {

        [JsonProperty( "ProductsList" )]
        public ObservableCollection<Product> ProductsList { get; set; } = new ObservableCollection<Product>();

    }
}
