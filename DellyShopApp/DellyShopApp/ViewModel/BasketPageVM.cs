using DellyShopApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DellyShopApp.ViewModel
{
    public class BasketPageVm : BaseVm
    {
        private ObservableCollection<ProductListModel> _procutListModel = new ObservableCollection<ProductListModel>();
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

        public ObservableCollection<ProductListModel> ProcutListModel
        {
            get => _procutListModel;
            set
            {
                _procutListModel = value;
                OnPropertyChanged(nameof(ProcutListModel));
            }
        }

        public BasketPageVm()
        {
            _procutListModel.Add(new ProductListModel
            {
                Title = "iPhone 8 Plus Gold",
                Brand = "Apple",
                Id = 1,
                Image = "iphone",
                Price = 499,
                VisibleItemDelete = false
            });
            _procutListModel.Add(new ProductListModel
            {
                Title = "Grey Firozi Mesh",
                Brand = "ASIAN",
                Id = 3,
                Image = "shoesblack2",
                Price = 150,
                VisibleItemDelete = false
            });
            _procutListModel.Add(new ProductListModel
            {
                Title = "Presto Yellow",
                Brand = "Nike",
                Id = 2,
                Image = "shoesyellow",
                Price = 299,
                VisibleItemDelete = false
            });
        }
    }
}