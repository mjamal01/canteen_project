using System;
using DellyShopApp.Models;
using DellyShopApp.Views.CustomView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DellyShopApp.ParentsData.CashHandling;
namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransSummarySmart
    {
        public TransSummarySmart()
        {
            InitializeComponent();
            UpdateTransactions();
            TransactionsList.ItemsSource = transactions;
        }

        private async void ClickItem(object sender, EventArgs e)
        {
            if (!(sender is PancakeView pancake)) return;
            if (!(pancake.BindingContext is ProductListModel item)) return;
            await Navigation.PushAsync(new ProductDetail(item));
        }
    }
}