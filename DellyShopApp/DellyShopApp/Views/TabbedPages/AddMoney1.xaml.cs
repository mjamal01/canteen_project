using DellyShopApp.CommonData;
using DellyShopApp.Models;
using DellyShopApp.ParentsData.CashHandling;
using DellyShopApp.Services;
using DellyShopApp.Views.CustomView;
using DellyShopApp.Views.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.TabbedPages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class AddMoney1 {
        public AddMoney1() {
            InitializeComponent();
            entryBalance.Text = string.Format( "{0:0.0}", 0 );
            LoadData();
        }

        private void LoadData() {
            var list = RestService.GetSchoolsList();

            schoolsPkr.ItemsSource = list; //list.Select( t => t.Name ).ToList();
        }

        private async void SaveButtonClick(object sender, EventArgs e) {

            double amount = 0;

            if ( !( schoolsPkr.SelectedItem is School selectedSchool ) ) {
                await DisplayAlert( "Warning", "Please select school and try again.", "Ok" );
                return;
            }

            if ( double.TryParse( entryBalance.Text, out amount ) ) {
                List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
                string url = $"{Global.WebApiUrl}/api/parent/AddMoney?parent_id={Global.ParentId}&amount={amount}&school_Id={selectedSchool.SchoolId}";

                try {

                    var result = HelperClass.PostRecord( url, pairs );
                    double balance = JsonConvert.DeserializeObject<double>( result );

                    await DisplayAlert( "Info", "Current Balance = " + HelperClass.DoFormat( balance ), "Ok" );
                } catch (Exception ex) {
                    await DisplayAlert( "Warning", "Unable to add money at this time try again later.", "Ok" );
                }
                //Navigation.PopAsync();
            } else {
                await DisplayAlert( "Warning", "Invalid Amount entered", "Ok" );
            }
            //await Navigation.PushAsync(new TransSummarySmart());

        }

        private void CancelButtonClick(System.Object sender, System.EventArgs e) {
            entryBalance.Text = "";
            //await Navigation.PushAsync(new TransSummarySimple());
        }
    }
}