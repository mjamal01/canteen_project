using DellyShopApp.CommonData;
using DellyShopApp.ParentsData.CashHandling;
using DellyShopApp.ViewModel;
using DellyShopApp.Views.CustomView;
using DellyShopApp.Views.Pages;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.TabbedPages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class ControlChildrenProducts {
        public ControlChildrenProducts() {
            InitializeComponent();
            InitializeChildrenData();
            ChildrenList.ItemsSource = ChildrenDetailList;

            //var result = HelperClass.GetStringRecord($"{Global.WebApiUrl}/api/parent/GetCurrentBalance?parent_id={Global.ParentId}");
            //decimal balance = JsonConvert.DeserializeObject<decimal>(result);
            //entryBalance.Text = string.Format("{0:0.0}", balance);
        }
        private async void TransSummaryButtonClick(object sender, EventArgs e) {
            if ( !( sender is PancakeView pancake ) )
                return;
            if ( !( pancake.BindingContext is IndividualChildDetail item ) )
                return;

            CurrentChildId = ( int ) item.customer_id;
            //await Navigation.PushAsync(new ProductDetail(item));
            await Navigation.PushAsync( new ChildrenProductsPage( item ) );
        }

        private async void TransSummarySimpleButtonClick(System.Object sender, System.EventArgs e) {
        }
    }
}