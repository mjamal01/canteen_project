using DellyShopApp.Models;
using DellyShopApp.ViewModel;
using DellyShopApp.Views.CustomView;
using System;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class SingleStudentProducts {
        public SingleStudentProducts(ChildWithProducts individualChildDetail) {
            InitializeComponent();
            SingleStudentProductsBasketItems.ItemsSource = individualChildDetail.ProductsList;
            //SingleStudentProductsBasketItems.ItemsSource = ProcutListModel;
        }

        private async void ClickItem(object sender, EventArgs e) {
            if ( !( sender is PancakeView pancake ) )
                return;

            //if (!(pancake.BindingContext is ProductListModel item)) return;
            //await Navigation.PushAsync(new ProductDetail(item));


            if ( !( pancake.BindingContext is Product item ) )
                return;

            ProductListModel productListModel = new ProductListModel() {
                Id = ( int ) item.Id,
                Brand = item.Name,
                Title = item.Name,
                Image = item.Image,
                Price = ( double ) item.Price,
            };

            CurrentProductId = productListModel.Id;
            await Navigation.PushAsync( new IndividualProductDetail( productListModel ) );
        }
    }
}