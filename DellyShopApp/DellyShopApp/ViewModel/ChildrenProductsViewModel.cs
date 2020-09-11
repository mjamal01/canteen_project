using DellyShopApp.CommonData;
using DellyShopApp.Extensions;
using DellyShopApp.Helpers;
using DellyShopApp.Models;
using DellyShopApp.Views.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DellyShopApp.ViewModel {
    public class ChildrenProductsViewModel : BaseVm {

        public ObservableCollection<Product> ProductsWithLimit { get; set; } = new ObservableCollection<Product>();
        public Dictionary<string, Dictionary<string, ObservableCollection<Product>>> ProductsWithDay { get; set; } = new Dictionary<string, Dictionary<string, ObservableCollection<Product>>>();


        private ChildWithProducts _ChildDetail;
        public ChildWithProducts ChildDetail {
            get => _ChildDetail;
            set {
                _ChildDetail = value;
                OnPropertyChanged( nameof( ChildDetail ) );
            }
        }

        private decimal _dialyLimit;
        public decimal DialyLimit {
            get => _dialyLimit;
            set {
                _dialyLimit = value;
                PresistDialyLimit();
                OnPropertyChanged( nameof( DialyLimit ) );
            }
        }

        private Color _canteenProductBtnColor;
        public Color CanteenProductBtnColor {
            get => _canteenProductBtnColor;
            set {
                _canteenProductBtnColor = value;
                OnPropertyChanged( nameof( CanteenProductBtnColor ) );
            }
        }
        private Color _sonsPurchasesBtnColor;
        public Color SonsPurchasesBtnColor {
            get => _sonsPurchasesBtnColor;
            set {
                _sonsPurchasesBtnColor = value;
                OnPropertyChanged( nameof( SonsPurchasesBtnColor ) );
            }
        }

        private Color _canteenProductBtnTextColor;
        public Color CanteenProductBtnTextColor {
            get => _canteenProductBtnTextColor;
            set {
                _canteenProductBtnTextColor = value;
                OnPropertyChanged( nameof( CanteenProductBtnTextColor ) );
            }
        }

        private Color _sonsPurchasesBtnTextColor;
        public Color SonsPurchasesBtnTextColor {
            get => _sonsPurchasesBtnTextColor;
            set {
                _sonsPurchasesBtnTextColor = value;
                OnPropertyChanged( nameof( SonsPurchasesBtnTextColor ) );
            }
        }

        private bool _showDialyLimitDialoge = false;
        public bool ShowDialyLimitDialoge {
            get => _showDialyLimitDialoge;
            set {
                _showDialyLimitDialoge = value;
                OnPropertyChanged( nameof( ShowDialyLimitDialoge ) );
            }
        }

        private bool _showCanteenProduct = true;
        public bool ShowCanteenProduct {
            get => _showCanteenProduct;
            set {
                _showCanteenProduct = value;
                OnPropertyChanged( nameof( ShowCanteenProduct ) );
            }
        }

        public List<string> WeekDays { get; set; } = new List<string>() {
            "Sunday", "Monday", "Tuesday", "Wednesday", "Thrusday", "Friday", "Saturday"
        };

        public List<string> WeekDaysAr { get; set; } = new List<string>() {
            "الاحد", "الاثنين", "الثلاثاء", "الاربعاء", "الخميس", "الجمعة", "السبت"
        };



        private int _selectedDay;
        public int SelectedDay {
            get => _selectedDay;
            set {
                _selectedDay = value;
                OnPropertyChanged( nameof( SelectedDay ) );
                UpdateCurrentProductsContext();
            }
        }

        public ICommand CanteenProductsCommand { get; set; }
        public ICommand SonsPurchasesCommand { get; set; }
        public ICommand SendBalanceCommand { get; set; }
        public ICommand EditDialyLimitCommand { get; set; }
        public ICommand EditInfoCommand { get; set; }
        public ICommand ItemAllowCommand { get; set; }
        public ICommand ItemSelectedCommand { get; set; }
        public ICommand UpdateDialyLimitCommand { get; set; }
        public ICommand HideDialogeBoxCommand { get; set; }
        public ICommand DeductItemCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand ShowWeeklyPlanCommand { get; set; }
        public ICommand UploadChildDialyLimitCommand { get; set; }

        public ChildrenProductsViewModel(ChildWithProducts detail) {

            ChildDetail = detail;
            CanteenProductsCommand = new Command( OnCanteenProducts );
            SonsPurchasesCommand = new Command( OnSonsPurchases );
            SendBalanceCommand = new Command( OnSendBalance );
            EditDialyLimitCommand = new Command( OnEditDialyLimit );
            EditInfoCommand = new Command( OnEditInfo );
            ItemAllowCommand = new Command<Product>( vm => OnItemAllow( vm ) );
            ItemSelectedCommand = new Command<Product>( vm => OnItemSelected( vm ) );
            UpdateDialyLimitCommand = new Command( OnUpdateDialyLimit );
            HideDialogeBoxCommand = new Command( OnHideDialogeBox );
            DeductItemCommand = new Command<Product>( vm => OnDeductItem( vm ) );
            AddItemCommand = new Command<Product>( vm => OnAddItem( vm ) );
            UploadChildDialyLimitCommand = new Command( OnUploadChildDialyLimit );
            ShowWeeklyPlanCommand = new Command( OnShowWeeklyPlan );
            UpdateByLanuguage();
            UpdateListView();
            SetDate();
            OnCanteenProducts();

        }

        private void OnShowWeeklyPlan() {
            var list = new List<ProductListWithlimit>();
            ProductsWithDay[ChildDetail.UniqueRef].ForEach( t => list.Add( new ProductListWithlimit( t.Key, t.Value ) ) );
            Application.Current.MainPage.Navigation.PushAsync( new WeeklyPlan( list ) );
            //Application.Current.MainPage.Navigation.PushAsync( new MyOrderPage() );

        }

        private void OnUploadChildDialyLimit() {
            try {
                var payLoad = new StudentLimitsUpdateByParent();
                payLoad.CustomerId = ChildDetail.Id;
                payLoad.DailyAllowedMoney = DialyLimit;

                ProductsWithLimit.ForEach( item => {
                    payLoad.listOfQtyLimits.Add( new ProductLimitsByParent() {
                        ProductId = item.Id,
                        QtyLimit = 0,
                        DailyQty7Days = GetDailyQty7Days( item.Id )
                    } );
                } );

                string limitData = JsonConvert.SerializeObject( payLoad );
                //Console.WriteLine( limitData );
                List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("data",limitData)
                };
                string result = HelperClass.PostRecord( $"{Global.WebApiUrl}/api/parent/UpdateProdLimits", pairs );

                MessagingCenter.Send( this, "LoadChildrenDetailList" );

                Application.Current.MainPage.DisplayAlert( "Info Message", result, "OK" );
            } catch ( Exception ex ) {
                Console.WriteLine( ex.StackTrace );
            }

        }

        private string GetDailyQty7Days(long pid) {
            var child7DaysPlan = ProductsWithDay[ChildDetail.UniqueRef];
            var itemsCoutList = ( child7DaysPlan.Select( (t) => t.Value
                                                         .Where( m => m.Id == pid )
                                                         .Select( l => l.Count.ToString() )
                                                         .FirstOrDefault() ) );
            return string.Join( ",", itemsCoutList );
        }

        private void UpdateByLanuguage() {
            if ( Settings.SelectLanguage == "ar" ) {
                WeekDays = WeekDaysAr;
            }
        }

        private void UpdateListView() {

            if ( ChildDetail == null ) {
                return;
            }

            if ( !ProductsWithDay.ContainsKey( ChildDetail.UniqueRef ) ) {
                ProductsWithDay[ChildDetail.UniqueRef] = new Dictionary<string, ObservableCollection<Product>>();
            }

            if ( ProductsWithDay[ChildDetail.UniqueRef].Count != 7 ) {

                var list = new List<Product>();
                ChildDetail.ProductsList.ForEach( t => list.Add( t ) );
                ProductsWithDay[ChildDetail.UniqueRef].Clear();
                WeekDays.ForEach( t => {
                    ProductsWithDay[ChildDetail.UniqueRef].Add( t, JsonConvert.DeserializeObject<ObservableCollection<Product>>( JsonConvert.SerializeObject( ChildDetail.ProductsList ) ) );
                } );
            }

            ProductsWithDay[ChildDetail.UniqueRef]
                .ForEach( p => p.Value.ForEach( t => t.Count = int.Parse( t.DailyQty7Days.Split( ',' )[WeekDays.IndexOf( p.Key )] ) ) );

            DialyLimit = ChildDetail.DailyCashLimit;
            UpdateCurrentProductsContext();

        }


        private void UpdateCurrentProductsContext() {

            var products = ProductsWithDay[ChildDetail.UniqueRef][WeekDays[SelectedDay]];
            ProductsWithLimit = products;
            OnPropertyChanged( nameof( ProductsWithLimit ) );
        }

        private void PresistDialyLimit() {
            var products = ProductsWithDay[ChildDetail.UniqueRef][WeekDays[SelectedDay]];
        }

        private void OnAddItem(Product vm) {
            if ( vm == null ) {
                return;
            }
            var items = vm.Count + 1;
            var totalAmount = ProductsWithLimit.Sum( t => t.Count * t.Price );
            totalAmount += vm.Price;
            if ( totalAmount > DialyLimit ) {
                App.Current.MainPage.DisplayAlert( "Error", "You cannot add items more than daily limit.", "Back" );
                return;
            }

            vm.Count += 1;

        }

        private void OnDeductItem(Product vm) {
            if ( vm == null || vm.Count == 0 ) {
                return;
            }

            vm.Count -= 1;

        }

        private void OnUpdateDialyLimit() {
            ShowDialyLimitDialoge = false;
        }

        private void OnHideDialogeBox() {
            ShowDialyLimitDialoge = false;
        }

        private void SetDate() {
            SelectedDay = 1;
        }

        private void OnEditInfo() {

        }

        private void OnEditDialyLimit() {
            ShowDialyLimitDialoge = true;
        }

        private void OnItemSelected(Product vm) {


        }

        private void OnItemAllow(Product vm) {


        }

        private void OnSendBalance() {


        }

        private void OnSonsPurchases() {
            SonsPurchasesBtnColor = Color.FromHex( "#4070b8" );
            CanteenProductBtnColor = Color.Transparent;
            CanteenProductBtnTextColor = Color.Black;
            SonsPurchasesBtnTextColor = Color.White;
            ShowCanteenProduct = false;

        }

        private void OnCanteenProducts() {
            CanteenProductBtnColor = Color.FromHex( "#4070b8" );
            SonsPurchasesBtnColor = Color.Transparent;
            SonsPurchasesBtnTextColor = Color.Black;
            CanteenProductBtnTextColor = Color.White;
            ShowCanteenProduct = true;


        }
    }
}
