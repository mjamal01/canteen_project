﻿using System;
using System.Globalization;
using System.Net;
using System.Threading;
using DellyShopApp.Helpers;
using DellyShopApp.Languages;
using DellyShopApp.Views.CustomView;
using DellyShopApp.Views.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation( XamlCompilationOptions.Compile )]
[assembly: ExportFont( "Simple-Line-Icons.ttf", Alias = "LineIcons" )]
namespace DellyShopApp {
    public partial class App {
        public App() {
            InitializeComponent();
            FlowListView.Init();

            Thread.CurrentThread.CurrentUICulture = new CultureInfo( Settings.SelectLanguage );
            AppResources.Culture = new CultureInfo( Settings.SelectLanguage );

            //MainPage navigation = new MainPage();
            var navigation = new LoginPage();  //new HomeTabbedPage(); // new CustHomePage(); //new LoginPage(); //
            NavigationPage navpage = new NavigationPage( navigation );
            NavigationPage.SetHasNavigationBar( navpage, false );
            NavigationPage.SetHasNavigationBar( navigation, false );
            MainPage = navpage;
            App.Current.MainPage.FlowDirection = Settings.SelectLanguage == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            LoadPlatForms();
        }

        private void LoadPlatForms() {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            Device.SetFlags( new[] { "SwipeView_Experimental" } );
        }
    }
}
