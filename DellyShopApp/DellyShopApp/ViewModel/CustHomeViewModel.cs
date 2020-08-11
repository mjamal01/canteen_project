using DellyShopApp.Helpers;
using DellyShopApp.Models;
using DellyShopApp.Views.Pages;
using DellyShopApp.Views.Pages.Base;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DellyShopApp.ViewModel {
    public class CustHomeViewModel : BaseVm {

        public ObservableCollection<IndividualChildDetail> ChildrenDetailList { get; set; } = new ObservableCollection<IndividualChildDetail>();

        private string _currency;
        public string Currenncy {
            get => _currency;
            set {
                _currency = value;
                OnPropertyChanged( nameof( Currenncy ) );
            }
        }

        private double _totalBalance;
        public double TotalBalance {
            get => _totalBalance;
            set {
                _totalBalance = value;
                OnPropertyChanged( nameof( TotalBalance ) );
            }
        }

        private double _creditLimitPercent;
        public double CreditLimitPercent {
            get => _creditLimitPercent;
            set {
                _creditLimitPercent = value;
                CreditLimitLabel = value * 100;
                OnPropertyChanged( nameof( CreditLimitPercent ) );
            }
        }

        private double _creditLimitLabel;
        public double CreditLimitLabel {
            get => _creditLimitLabel;
            set {
                _creditLimitLabel = value;
                OnPropertyChanged( nameof( CreditLimitLabel ) );
            }
        }

        public ICommand ChartRefreshCommand { get; set; }

        public ICommand CreditLimitCommand { get; set; }
        public ICommand NavigateToDetailPageCommand { get; set; }

        private static readonly SKColor AccentColor = SKColor.Parse( "#2C5DF9" );

        private static readonly SKColor AccentDarkColor = SKColor.Parse( "#484F64" );

        private static readonly SKColor OrangeColor = SKColor.Parse( "#FFD45F" );

        private static readonly SKColor GreenColor = SKColor.Parse( "#26C3AC" );

        private static readonly SKColor PinkColor = SKColor.Parse( "#FA6978" );


        private Chart _AltitudeChart;
        public Chart AltitudeChart {
            get => _AltitudeChart;
            set {
                _AltitudeChart = value;
                OnPropertyChanged( nameof( AltitudeChart ) );
            }
        }

        public void LoadChildrens() {
            ChildrenDetailList = BasePage.ChildrenDetailList;
            OnPropertyChanged( nameof( ChildrenDetailList ) );
            SetChart();
        }

        public CustHomeViewModel() {
            TotalBalance = 16945;
            Currenncy = "SR";
            ChartRefreshCommand = new Command( OnChartRefresh );
            CreditLimitCommand = new Command( OnCreditLimit );
            NavigateToDetailPageCommand = new Command<IndividualChildDetail>( vm => OnNavigateToDetailPage( vm ) );
            SetChart();
            SetCreditLimit();
        }

        private void OnNavigateToDetailPage(IndividualChildDetail vm) {
            App.Current.MainPage.Navigation.PushAsync( new ChildrenProductsPage( vm ) );
        }

        private async void SetCreditLimit() {
            CreditLimitPercent = 0;
            await Task.Run( async () => {

                for ( double i = 0; i < .72; i += .01 ) {

                    //Console.WriteLine( i );
                    await Task.Delay( 30 );
                    CreditLimitPercent = i;
                }

            } );
        }

        private IEnumerable<ChartEntry> GetChildrens() {
            //
            List<ChartEntry> list = new List<ChartEntry>();
            foreach ( var item in ChildrenDetailList ) {
                list.Add( new ChartEntry( ( float ) item.DailyCashLimit ) {

                    Label = item.name,
                    ValueLabel = item.DailyCashLimit.ToString( "0" ),
                    Color = SKColor.Parse( "#8349f5" )
                } );
            }
            return list.AsEnumerable();
        }

        private void SetChart() {
            AltitudeChart = new LineChart() {
                Entries = GetChildrens(),
                ValueLabelOrientation = Orientation.Horizontal,
                LineSize = 18,
                IsAnimated = true,
                PointMode = PointMode.Circle,
                PointSize = 30,
                LabelTextSize = 25,
                LabelOrientation = Orientation.Horizontal,
                BackgroundColor = SKColors.Transparent
            };
        }

        private void OnCreditLimit(object vm) {
            //Application.Current.MainPage.DisplayAlert( "OnCreditLimit clicked", "OK", "BACK" );
            SetCreditLimit();

        }

        private void OnChartRefresh(object vm) {
            SetChart();
        }
    }
}
