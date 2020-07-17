using DellyShopApp.CommonData;
using DellyShopApp.ParentsData.CashHandling;
using DellyShopApp.Views.CustomView;
using DellyShopApp.Views.Pages;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransSummaryConfig
    {
        public TransSummaryConfig()
        {
            InitializeComponent();
            var result = HelperClass.GetStringRecord($"{Global.WebApiUrl}/api/parent/GetCurrentBalance?parent_id={Global.ParentId}");
            decimal balance = JsonConvert.DeserializeObject<decimal>(result);
            entryBalance.Text = string.Format("{0:0.0}", balance);
        }
        private async void TransSummaryButtonClick(object sender, EventArgs e)
        {
            Global.SummaryStart = startDatePicker.Date;
            Global.SummaryEnd = endDatePicker.Date;

            string szStart = Global.SummaryStart.ToString("yyyy-MM-dd");
            string szEnd = Global.SummaryEnd.ToString("yyyy-MM-dd");
            var result = HelperClass.GetStringRecord($"{Global.WebApiUrl}/api/parent/GetCashTransDetail?id={Global.ParentId}&start={szStart}&end={szEnd}");
            if (result == "\"Cash transactions not found\"")
            {
                await DisplayAlert("Warning", "No cash transaction found", "Ok");
            }
            else
            {
                Global.CashTransDetail = result;
                await Navigation.PushAsync(new TransSummarySmart());
            }
        }

        private async void TransSummarySimpleButtonClick(System.Object sender, System.EventArgs e)
        {
            Global.SummaryStart = startDatePicker.Date;
            Global.SummaryEnd = endDatePicker.Date;

            string szStart = Global.SummaryStart.ToString("yyyy-MM-dd");
            string szEnd = Global.SummaryEnd.ToString("yyyy-MM-dd");
            var result = HelperClass.GetStringRecord($"{Global.WebApiUrl}/api/parent/GetCashTransDetail?id={Global.ParentId}&start={szStart}&end={szEnd}");
            if (result == "\"Cash transactions not found\"")
            {
                await DisplayAlert("Warning", "No cash transaction found", "Ok");
            }
            else
            {
                Global.CashTransDetail = result;
                await Navigation.PushAsync(new TransSummarySimple());
            }
        }
        private async void RefreshBalanceButtonClick(System.Object sender, System.EventArgs e)
        {
            var result = HelperClass.GetStringRecord($"{Global.WebApiUrl}/api/parent/GetCurrentBalance?parent_id={Global.ParentId}");
            decimal balance = JsonConvert.DeserializeObject<decimal>(result);
            entryBalance.Text = string.Format("{0:0.0}", balance);
        }
    }
}