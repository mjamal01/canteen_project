using System;
using System.Globalization;
using System.Threading;
using DellyShopApp.Helpers;
using DellyShopApp.Languages;
using DellyShopApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static DellyShopApp.ThemeManager;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class SettingsPage {
        string[] languages = { "English", "العربية" };
        public SettingsPage() {

            InitializeComponent();
            languageLabel.Text = Settings.SelectLanguage == "ar" ? "العربية" : "English";
        }

        protected void Toggled(object sender, ToggledEventArgs args) {
            if ( args.Value ) {
                ThemeManager.ChangeTheme( Themes.Dark );
            } else {
                ThemeManager.ChangeTheme( Themes.White );
            }
        }
        protected void LogOutClick(object sender, EventArgs args) {
            Application.Current.MainPage = new NavigationPage( new LoginPage() );
        }
        protected async void SelectLanguage(object sender, EventArgs args) {
            AppServices.SelectLanguage();
        }
    }
}