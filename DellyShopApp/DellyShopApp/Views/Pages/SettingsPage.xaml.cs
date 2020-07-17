using System;
using System.Globalization;
using System.Threading;
using DellyShopApp.Helpers;
using DellyShopApp.Languages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static DellyShopApp.ThemeManager;

namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage
    {
        string[] languages = { "English", "العربية" };
        public SettingsPage()
        {

            InitializeComponent();
            languageLabel.Text = Settings.SelectLanguage == "ar" ? "العربية" : "English";
        }

        protected void Toggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                ThemeManager.ChangeTheme(0);
            }
            else
            {
                ThemeManager.ChangeTheme(Themes.White);
            }
        }
        protected void LogOutClick(object sender, EventArgs args)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        protected async void SelectLanguage(object sender, EventArgs args)
        {
            var selectlanguage = await DisplayActionSheet(AppResources.SelectLanguage, AppResources.Cancel, AppResources.Cancel, languages);
            switch (selectlanguage)
            {
                case "English":
                    Settings.SelectLanguage = "en";
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    AppResources.Culture = new CultureInfo("en");
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                    break;
                case "العربية":
                    Settings.SelectLanguage = "ar";
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
                    AppResources.Culture = new CultureInfo("ar");
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                    break;
                default:
                    break;
            }
        }
    }
}