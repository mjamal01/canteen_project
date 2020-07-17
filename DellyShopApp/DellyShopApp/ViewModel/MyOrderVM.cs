using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShopApp.ViewModel
{
   public class MyOrderVM : BaseVm
   {
       private bool _openDetailOrder;
        public bool OpenDetailOrder { get=>
            _openDetailOrder;
            set
            {
                _openDetailOrder = value;
                OnPropertyChanged(nameof(OpenDetailOrder));
            }
        }
    }
}
