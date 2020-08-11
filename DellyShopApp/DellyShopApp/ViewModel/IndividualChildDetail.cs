using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DellyShopApp.ViewModel  {
    public class IndividualChildDetail  {
        public long customer_id { get; set; }
        public string name { get; set; }
        public string customer_image { get; set; }
        public decimal DailyCashLimit { get; set; }
        public string UniqueRef { get; set; }
        public ObservableCollection<productsWithQtyLimitMobile> ProductsList { get; set; } = new ObservableCollection<productsWithQtyLimitMobile>();
        public IndividualChildDetail() {
            customer_id = 0;
            name = "";
            DailyCashLimit = 0;
            UniqueRef = "";
        }
    }
    public class productsWithQtyLimitMobile : BaseVm {
        public long id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
        public string DailyQty7Days { get; set; } 
         
        private int _count = 0 ;
        public int Count {
            get => _count;
            set {
                _count = value;
                OnPropertyChanged( nameof( Count ) );
            }
        }

        public productsWithQtyLimitMobile() {
            id = 0;
            name = "";
            price = 0;
            image = "";
            DailyQty7Days = "";
        }
    }
}
