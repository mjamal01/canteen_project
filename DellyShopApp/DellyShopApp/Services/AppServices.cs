﻿using DellyShopApp.Helpers;
using DellyShopApp.Languages;
using DellyShopApp.Views.Pages;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DellyShopApp.Services {
    public static class AppServices {

        private static Page MainPage => Application.Current.MainPage;
        private static Page CurrentPage => Application.Current.MainPage;
        public readonly static Dictionary<string, string> Languages = new Dictionary<string, string>() {
            ["en"] = "English",
            ["ar"] = "العربية"
        };

        public static async void SelectLanguage() {

            if ( CurrentPage == null ) {
                return;
            }
            string[] languages = { "English", "العربية" };

            var selectlanguage = await CurrentPage.DisplayActionSheet( AppResources.SelectLanguage, AppResources.Cancel, AppResources.Cancel, languages );

            switch ( selectlanguage ) {
                case "English":

                    if ( Settings.SelectLanguage == "ar" ) {
                        Settings.SelectLanguage = "en";
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo( "en" );
                        AppResources.Culture = new CultureInfo( "en" );
                        Application.Current.MainPage = new NavigationPage( new LoginPage() );
                        SetPageFlow();
                    }

                    break;
                case "العربية":

                    if ( Settings.SelectLanguage == "en" ) {
                        Settings.SelectLanguage = "ar";
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo( "ar" );
                        AppResources.Culture = new CultureInfo( "ar" );
                        Application.Current.MainPage = new NavigationPage( new LoginPage() );
                        SetPageFlow();
                    }

                    break;
                default:
                    break;
            }

            void SetPageFlow() {
                Application.Current.MainPage.FlowDirection = Settings.SelectLanguage == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            }
        }

        public static async Task<ImageSource> PickImageFromPhone() {
            var initialize = await CrossMedia.Current.Initialize();

            if ( !CrossMedia.Current.IsPickPhotoSupported ) {
                await MainPage.DisplayAlert( "Access denied", "No access available.", "OK" );
                return null;
            }

            //new Plugin.Media.Abstractions.StoreCameraMediaOptions {
            //    Directory = "Sample",
            //    Name = "test.jpg"
            //}

            var file = await CrossMedia.Current.PickPhotoAsync();

            if ( file == null )
                return null;

            //await MainPage.DisplayAlert( "File Location", file.Path, "OK" );

            var imageSource = ImageSource.FromStream( () => {
                var stream = file.GetStream();
                return stream;
            } );

            return imageSource;
        }

    }
}
