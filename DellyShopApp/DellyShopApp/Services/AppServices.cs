using DellyShopApp.Helpers;
using DellyShopApp.Languages;
using DellyShopApp.Views.Pages;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DellyShopApp.Services {
    public static class AppServices {
        public static readonly Dictionary<string, string> Languages = new Dictionary<string, string>() {
            ["en"] = "English",
            ["ar"] = "العربية"
        };

        private static Page CurrentPage {
            get => Application.Current.MainPage;
            set => Application.Current.MainPage = value;
        }

        public static async void SelectLanguage() {
            if ( AppServices.CurrentPage == null )
                return;
            try {
                string selectlanguage = await AppServices.CurrentPage.DisplayActionSheet( AppResources.SelectLanguage, "", "", AppServices.Languages.Select( t => t.Value ).ToArray<string>() );
                if ( selectlanguage == AppServices.Languages["en"] ) {
                    if ( Settings.SelectLanguage == "ar" ) {
                        Settings.SelectLanguage = "en";
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo( "en" );
                        AppResources.Culture = new CultureInfo( "en" );
                        AppServices.CurrentPage = ( Page ) new NavigationPage( ( Page ) new LoginPage() );
                        AppServices.SetPageFlow();
                    } else
                        await AppServices.CurrentPage.DisplayAlert( "Waning", "Selected language is already " + selectlanguage, "Back" );
                } else if ( selectlanguage == AppServices.Languages["ar"] ) {
                    if ( Settings.SelectLanguage == "en" ) {
                        Settings.SelectLanguage = "ar";
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo( "ar" );
                        AppResources.Culture = new CultureInfo( "ar" );
                        AppServices.CurrentPage = ( Page ) new NavigationPage( ( Page ) new LoginPage() );
                        AppServices.SetPageFlow();
                    } else
                        await AppServices.CurrentPage.DisplayAlert( "Waning", "Selected language is already " + selectlanguage, "Back" );
                } else
                    await AppServices.CurrentPage.DisplayAlert( "Waning", "No language is selected.", "Back" );
                selectlanguage = ( string ) null;
            } catch ( Exception ex ) {
                await AppServices.CurrentPage.DisplayAlert( "Error", "Unable to change language please try again later. " + ex.Message, "Back" );
            }
        }

        public static void SetPageFlow() => AppServices.CurrentPage.FlowDirection = Settings.SelectLanguage == "ar" ? ( FlowDirection ) 2 : ( FlowDirection ) 1;

        public static async Task<MediaFile> PickImageFromPhone() {

            bool initialize = await CrossMedia.Current.Initialize();
            if ( !CrossMedia.Current.IsPickPhotoSupported ) {
                await AppServices.CurrentPage.DisplayAlert( "Access denied", "No access available.", "OK" );
                return null;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();
            return file;
        }

        public static bool IsValidAqamaId(string id) => id.Length == 10 & AppServices.IsNumberOnly( id );

        public static bool IsValidFullName(string email) => Regex.Match( email, "^[a-zA-Z ]*$" ).Success;

        public static bool IsValidEmail(string email) => Regex.Match( email, "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$" ).Success;

        public static bool IsValidPhoneNumber(string phone) => phone.Length == 14 & phone.StartsWith( "00" ) & AppServices.IsNumberOnly( phone );

        public static bool IsNumberOnly(string number) => Regex.Match( number, "^[0-9]*$" ).Success;
    }
}
