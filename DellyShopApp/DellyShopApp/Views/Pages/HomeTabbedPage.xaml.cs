using DellyShopApp.Helpers;
using DellyShopApp.Views.TabbedPages;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class HomeTabbedPage : TabbedPage {

        public static HomeTabbedPage Current { get; private set; }
        public HomeTabbedPage() {
            InitializeComponent();
            Current = this;
            if ( Settings.SelectLanguage == "ar" ) {
                var list = new List<Page>();
                Children.Reverse().ForEach( t => list.Add( t ) );
                Children.Clear();
                list.ForEach( t => Children.Add( t ) );
                CurrentPage = Children.LastOrDefault();
            }

        }

        public void SetAddMoneyPage() {
            var page = Children.First( p => p is AddMoney1 );
            if ( page != null )
                CurrentPage = page;
            else
                Application.Current.MainPage.DisplayAlert( "Error", "Unable to open topup page.", "Back" );
        }
    }
}