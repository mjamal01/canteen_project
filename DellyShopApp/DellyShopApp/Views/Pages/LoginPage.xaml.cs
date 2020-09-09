using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using DellyShopApp.CommonData;
using DellyShopApp.Helpers;
using DellyShopApp.Languages;
using DellyShopApp.Models;
using DellyShopApp.Services;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class LoginPage {

        private string[] languages = { "English", "العربية" };

        private string language;
        public string Language {
            get {
                return language;
            }
            set {
                language = value;
                OnPropertyChanged();
            }
        }



        public LoginPage() {

            InitializeComponent();
            BindingContext = this;
            EntryUserName.Text = "msajjadh@gmail.com";
            EntryPassword.Text = "31180";
            CheckLang();

        }

        private void CheckLang() {
            if ( Settings.SelectLanguage == "ar" ) {
                Language = languages[0];
            } else {
                Language = languages[1];
            }
        }

        private async void LoginButtonClick(object sender, EventArgs e) {
            LoginButton.IsEnabled = false;
            if ( string.IsNullOrEmpty( EntryUserName.Text ) || string.IsNullOrEmpty( EntryPassword.Text ) ) {
                await DisplayAlert( "Error", "User name or password cannot be empty.", "ok" );
                LoginButton.IsEnabled = true;
                return;
            }

            try {

                //Here first complete the login process
                var keyValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username", EntryUserName.Text),
                    new KeyValuePair<string, string>("password", EntryPassword.Text),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("response_type", "token"),
                };

                var content = new FormUrlEncodedContent( keyValues );
                var response = HelperClass.PostRecord( $"{Global.WebApiUrl}/token", content );
                //var request = new HttpRequestMessage( HttpMethod.Post, string.Format( @"{0}/token", Global.WebApiUrl ) );
                //request.Content = new FormUrlEncodedContent( keyValues );
                //request.Headers.Add( "IsMobileApp", "1" );
                //request.Headers.Add("Content-Type", "application/json; charset=UTF-8");
                //var client = new HttpClient();
                //var response = await client.SendAsync( request );
                //var content = await response.Content.ReadAsStringAsync();
                var loginToken = JsonConvert.DeserializeObject<LoginToken>( response );
                var accessToken = loginToken.AccessToken;
                if ( !string.IsNullOrEmpty( accessToken ) ) {

                    Global.token = accessToken;
                    //Here get the user info
                    var result = HelperClass.GetRecord( $"{Global.WebApiUrl}/api/user/GetUserInfoMobile?username={EntryUserName.Text}" );

                    var userInfo = JsonConvert.DeserializeObject<UserInfo>( result );

                    Global.Username = userInfo.Username;
                    Global.LoggedInUserId = userInfo.UserId;
                    Global.GroupId = userInfo.GroupId;
                    Global.ParentId = userInfo.ParentId;
                    Global.ParentName = userInfo.ParentName;
                    //await DisplayAlert("Login", "Login Successful", "ok");
                    if ( Global.GroupId == 3 ) {
                        await Navigation.PushAsync( new HomeTabbedPage() );
                        //await Navigation.PushAsync(new ParentsData.CashHandling.TransSummaryConfig());
                    } else {
                        LoginButton.IsEnabled = true;
                        await DisplayAlert( "View", "View for admin is not available.", "ok" );
                    }
                } else {
                    Global.token = "";
                    LoginButton.IsEnabled = true;
                    await DisplayAlert( "Login", "Login Failed, Try Again.", "ok" );
                }

            } catch ( Exception ex ) {
                Global.token = "";
                LoginButton.IsEnabled = true;
                //status.Text = "Host is not accessible.";
                await DisplayAlert( "Login", "Host is not accessible.", "ok" );
            }

            //await Navigation.PushAsync(new HomeTabbedPage());
        }
        private void BackButton(object sender, EventArgs e) {
            Navigation.PopAsync();
        }
        private async void ForgetPassClick(object sender, EventArgs e) {
            string result = await DisplayPromptAsync( AppResources.ForgotPass,
                AppResources.EnterEmailAddress );
            if ( string.IsNullOrEmpty( result ) )
                return;
            await DisplayAlert( AppResources.Success,
                AppResources.SuccessSendEmail
                + " " + result, AppResources.Okay );
        }

        private void SignUpTabbed(object sender, EventArgs e) {
            Navigation.PushAsync( new SignupParentPage() );
        }

        private void ChangeLangTabbed(object sender, EventArgs e) {
            AppServices.SelectLanguage();
        }

        private void TandCTabbed(object sender, EventArgs e) {
            Navigation.PushAsync( new TermsAndConditionsPage() );
        }

        private void ForgotPasswordTabbed(object sender, EventArgs e) {
            Navigation.PushAsync( new ForgotPasswordPage() );
        }
    }
}