using System;
using System.Collections.Generic;
using System.Text;
using DellyShopApp.ViewModel;

namespace DellyShopApp.Models
{
    public class ProductListModel : BaseVm
    {
        private bool _visibleDeleteItem;
        public bool VisibleItemDelete
        {
            get => _visibleDeleteItem;
            set
            {
                _visibleDeleteItem = value;
                OnPropertyChanged(nameof(VisibleItemDelete));
            }
        }

        
        private int _rotate;
        public int Rotate
        {
            get => _rotate;
            set
            {
                _rotate = value;
                OnPropertyChanged(nameof(Rotate));
            }
        }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
        public string[] ProductList { get; set; }

    }
}

