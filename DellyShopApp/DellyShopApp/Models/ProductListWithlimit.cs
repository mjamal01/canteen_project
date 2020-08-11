using DellyShopApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DellyShopApp.Models {
    public class ProductListWithlimit : BaseVm {

        private string _weekDay;
        public string WeekDay {
            get => _weekDay;
            set {
                _weekDay = value;
                OnPropertyChanged( nameof( WeekDay ) );
            }
        }

        private decimal _dialyLimit;
        public decimal DialyLimit {
            get => _dialyLimit;
            set {
                _dialyLimit = value;
                OnPropertyChanged( nameof( DialyLimit ) );
            }
        }

        public ObservableCollection<productsWithQtyLimitMobile> ProductsList { get; set; } = new ObservableCollection<productsWithQtyLimitMobile>();

    }



}
