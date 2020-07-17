using System;
using System.Collections.Generic;
using System.ComponentModel;
using DellyShopApp.Languages;
using DellyShopApp.Models;
using DellyShopApp.Views.CustomView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class BestSellerPage 
    {
        public BestSellerPage()
        {
            InitializeComponent();
            BestSeller.FlowItemsSource = ProcutListModel;
        }
        private async void ProductDetailClick(object sender, EventArgs e)
        {
            if (!(sender is PancakeView pancake)) return;
            if (!(pancake.BindingContext is ProductListModel item)) return;
            await Navigation.PushAsync(new ProductDetail(item));
        }
        void BestSeller_Refreshing(System.Object sender, System.EventArgs e)
        {
            ProcutListModel.Insert(0, new ProductListModel
            {
                Title = AppResources.ProcutTitle3,
                Brand = AppResources.ProductBrand3,

                Id = 4,
                Image = "iphone",
                Price = 499,
                VisibleItemDelete = false,
                ProductList = new string[] { "ip8_1", "ip8_2" }
            });
            BestSeller.IsRefreshing = false;
        }
    }
}
