using DellyShopApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DellyShopApp.Models {
    public class ProductListWithlimit : ObservableCollection<Product> {
        public string DayOfWeek { get; set; }

        public ProductListWithlimit(string dayOfWeek, ObservableCollection<Product> products) : base( products ) {
            DayOfWeek = dayOfWeek;
        }

        public override string ToString() {
            return DayOfWeek;
        }
    }

}
