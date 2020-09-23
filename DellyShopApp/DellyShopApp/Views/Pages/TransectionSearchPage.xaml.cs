using DellyShopApp.CommonData;
using DellyShopApp.Models;
using DellyShopApp.ParentsData.CashHandling;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class TransectionSearchPage : ContentPage {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TransectionSearchPage() {
            InitializeComponent();
            BindingContext = this;
        }

        private void StartDataSelected(object sender, DateChangedEventArgs e) {
            if ( e.NewDate != null ) {
                StartDate = e.NewDate;
            }
        }

        private void EndDataSelected(object sender, DateChangedEventArgs e) {
            if ( e.NewDate != null ) {
                EndDate = e.NewDate;
            }
        }

        private async void SearchListClick(object sender, EventArgs e) {

            StartDate = pkrStartDate.Date;
            EndDate = pkrEndDate.Date;

            if ( StartDate == null ) {
                await DisplayAlert( "Sart date", "Please select start date and try again.", "Okay" );
                return;
            }

            if ( EndDate == null ) {
                await DisplayAlert( "Sart date", "Please select end date and try again.", "Okay" );
                return;
            }

            try {

                var start = StartDate.ToString( "yyyy-MM-dd" );
                var end = EndDate.ToString( "yyyy-MM-dd" );
                var url = $"{Global.WebApiUrl}/api/parent/GetCashTransDetail?id={Global.ParentId}&start={start}&end={end}";

                var response = HelperClass.GetRecord( url );
                var list = JsonConvert.DeserializeObject<List<Transection>>( response );

                if ( list == null || list.Count == 0 ) {
                    throw new Exception( "No cash transaction found" );
                }

                await Navigation.PushAsync( new TransectionListPage( list ) );

            } catch ( Exception ex ) {

                await DisplayAlert( "Warning", "No cash transaction found", "Ok" );

            }

        }
    }
}