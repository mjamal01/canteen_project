using System;
using DellyShopApp.Models;
using DellyShopApp.Views.CustomView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DellyShopApp.ParentsData.CashHandling;
using DellyShopApp.ViewModel;
using System.Collections.Generic;
using DellyShopApp.Views.TabbedPages;
using Newtonsoft.Json;
using DellyShopApp.CommonData;
using DellyShopApp.Views.Pages.Base;
using Xamarin.Forms.Internals;
using System.Linq;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class SingleChildDetail {
        public string formTitle { get; set; }
        private IndividualChildDetail individualChildDetail { get; set; }
        public SingleChildDetail(IndividualChildDetail ArgindividualChildDetail) {
            individualChildDetail = ArgindividualChildDetail;
            InitializeComponent();
            ChildName.Text = individualChildDetail.name;
            List<string> weekDays = new List<string>() { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            DayPicker.ItemsSource = weekDays;
            DayPicker.SelectedIndex = 0;
            MaxAmountPerDay.Text = individualChildDetail.DailyCashLimit.ToString();
            //UpdateTransactions();
            //SingleChildInfo.ItemsSource = individualChildDetail.ProductsList;
        }

        private async void ClickItem(object sender, EventArgs e) {
            if ( !( sender is PancakeView pancake ) )
                return;
            if ( !( pancake.BindingContext is ProductListModel item ) )
                return;
            await Navigation.PushAsync( new ProductDetail( item ) );
        }

        private async void ClickUpdate(System.Object sender, System.EventArgs e) {
            CurrentDayIndex = DayPicker.SelectedIndex;
            await Navigation.PushAsync( new SingleStudentProducts( individualChildDetail ) );
        }
        private async void ClickViewWeeklyPlan(System.Object sender, System.EventArgs e) {
            // await Navigation.PushAsync(new WeeklyPlanOld2());
        }
        private async void ClickSave(System.Object sender, System.EventArgs e) {
            //var data = ParentsHome2ViewModel.list_productsWithQtyLmtMob_light;
            StudentLimitsUpdateByParent studentLimitsUpdateByParent = new StudentLimitsUpdateByParent();
            studentLimitsUpdateByParent.CustomerId = CurrentChildId;
            studentLimitsUpdateByParent.DailyAllowedMoney = decimal.Parse( MaxAmountPerDay.Text );

            var studentRec = ChildrenDetailList.Where( item => item.customer_id == CurrentChildId ).ToList().FirstOrDefault();
            studentRec.ProductsList.ForEach( item => {
                studentLimitsUpdateByParent.listOfQtyLimits.Add( new ProductLimitsByParent() { ProductId = item.id, QtyLimit = 0, DailyQty7Days = item.DailyQty7Days } );
            } );
            studentRec.DailyCashLimit = decimal.Parse( MaxAmountPerDay.Text );
            string limitData = JsonConvert.SerializeObject( studentLimitsUpdateByParent );
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("data",limitData)
            };
            string result = HelperClass.PostRecord( $"{Global.WebApiUrl}/api/parent/UpdateProdLimits", pairs );
            await DisplayAlert( "Info Message", result, "OK" );
        }

    }
}