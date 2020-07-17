using System;
using DellyShopApp.Models;
using DellyShopApp.Views.CustomView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LastViewPage
    {
        public LastViewPage()
        {
            InitializeComponent();
            LastViewList.ItemsSource = ProcutListModel;
        }

        private async void ClickItem(object sender, EventArgs e)
        {
            if (!(sender is PancakeView pancake)) return;
            if (!(pancake.BindingContext is ProductListModel item)) return;
            await Navigation.PushAsync(new ProductDetail(item));
        }
    }
}