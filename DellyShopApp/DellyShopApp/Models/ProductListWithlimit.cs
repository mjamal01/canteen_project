using DellyShopApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DellyShopApp.Models {
    public class ProductListWithlimit : BaseVm { 
        public ObservableCollection<productsWithQtyLimitMobile> ProductsList { get; set; } = new ObservableCollection<productsWithQtyLimitMobile>(); 
    } 

}
