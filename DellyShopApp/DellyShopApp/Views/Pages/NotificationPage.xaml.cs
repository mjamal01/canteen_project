using DellyShopApp.Models;
using DellyShopApp.Views.CustomView;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationPage
    {

        public NotificationPage()
        {
            InitializeComponent();
            NotificationItems.ItemsSource = NotificationList;
        }

        private async void ClickItem(object sender, EventArgs e)
        {
            if (!(sender is PancakeView pancake)) return;
            if (!(pancake.BindingContext is NotificationModel item)) return;
            await Navigation.PushAsync(new NotificationDetail(item));
        }
    }
}