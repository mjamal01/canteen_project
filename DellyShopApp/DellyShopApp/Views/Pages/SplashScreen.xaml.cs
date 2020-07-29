using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class SplashScreen  {
        public SplashScreen() {
            InitializeComponent();
        } 

        protected override void OnAppearing() {
            base.OnAppearing();
            Navigation.PushAsync(new LoginPage());
        }

    } 

}