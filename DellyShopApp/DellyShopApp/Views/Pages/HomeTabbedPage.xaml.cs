using DellyShopApp.Helpers;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class HomeTabbedPage : TabbedPage {
        public HomeTabbedPage() {
            InitializeComponent();

            if ( Settings.SelectLanguage == "ar" ) {
                var list = new List<Page>();
                Children.Reverse().ForEach( t => list.Add( t ) );
                Children.Clear();
                list.ForEach( t => Children.Add( t ) );
                CurrentPage = Children.LastOrDefault();
            }

        }
    }
}