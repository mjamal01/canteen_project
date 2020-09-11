using DellyShopApp.CommonData;
using DellyShopApp.Models;
using DellyShopApp.ParentsData.CashHandling;
using DellyShopApp.Services;
using DellyShopApp.ViewModel;
using DellyShopApp.Views.CustomView;
using DellyShopApp.Views.Pages;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.TabbedPages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class ControlChildrenProducts {

        public ICommand DeleteChildCommnad { get; set; }
        public ControlChildrenProducts() {
            InitializeComponent();
            //InitializeChildrenData();
            BindingContext = this;
            DeleteChildCommnad = new Command<ChildWithProducts>( vm => OnDeleteChild( vm ) );
        }

        private void OnDeleteChild(ChildWithProducts vm) {
            Console.WriteLine( vm );

            try {

                string url = $"{Global.WebApiUrl}/api/cust/delete?id={vm.Id}";


                var result = HelperClass.SendRecord( url, new MultipartContent(), "DELETE" );

                DisplayAlert( "Info", result, "Ok" );

                ChildrenList.ItemsSource = RestService.GetChildrenMoneyAndProductsDetail( true );
            } catch ( Exception ex ) {
                DisplayAlert( "Error", "Unable to delete child at this time. Try again later", "Okay" );
            }

        }

        private async void TransSummaryButtonClick(object sender, EventArgs e) {

            if ( !( sender is ContentView view ) )
                return;

            if ( !( view.BindingContext is ChildWithProducts item ) )
                return;

            CurrentChildId = ( int ) item.Id;
            //await Navigation.PushAsync(new ProductDetail(item));
            await Navigation.PushAsync( new AddChildPage( item ) );
        }

        private void TransSummarySimpleButtonClick(System.Object sender, System.EventArgs e) {
        }

        private async void AddChildClick(object sender, EventArgs e) {
            await Navigation.PushAsync( new AddChildPage() );
        }


        protected override void OnAppearing() {
            base.OnAppearing();
            ChildrenList.ItemsSource = RestService.GetChildrenMoneyAndProductsDetail();
        }
    }
}