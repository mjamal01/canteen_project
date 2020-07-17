using DellyShopApp.Models;
using DellyShopApp.Views.CustomView;
using System;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFavoritePage
    {
        public MyFavoritePage()
        {
            InitializeComponent();
            BasketItems.ItemsSource = ProcutListModel;
        }

        private async void ClickItem(object sender, EventArgs e)
        {
            if (!(sender is PancakeView pancake)) return;
            if (!(pancake.BindingContext is ProductListModel item)) return;
            await Navigation.PushAsync(new ProductDetail(item));
        }
    }
}