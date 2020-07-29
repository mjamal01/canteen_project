using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using DellyShopApp.CommonData;
using DellyShopApp.Languages;
using DellyShopApp.Models;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class LoginPage {
        public string accessToken = "";
        public LoginPage() {
            InitializeComponent();
            //EntryUserName.Text = "msajjadh@gmail.com";
            //EntryPassword.Text = "31180";
        }

        private async void LoginButtonClick(object sender, EventArgs e) {
            LoginButton.IsEnabled = false;
            if ( EntryUserName.Text == "" || EntryPassword.Text == "" || EntryUserName.Text == null || EntryPassword.Text == null ) {
                await DisplayAlert( "Error", "User name or password cannot be empty.", "ok" );
                LoginButton.IsEnabled = true;
                return;
            }
            //Here first complete the login process
            var keyValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username", EntryUserName.Text),
                    new KeyValuePair<string, string>("password", EntryPassword.Text),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("response_type", "token"),
                };


            try {
                var request = new HttpRequestMessage( HttpMethod.Post, string.Format( @"{0}/token", Global.WebApiUrl ) );
                request.Content = new FormUrlEncodedContent( keyValues );
                request.Headers.Add( "IsMobileApp", "1" );
                //request.Headers.Add("Content-Type", "application/json; charset=UTF-8");
                var client = new HttpClient();
                var response = await client.SendAsync( request );
                var content = await response.Content.ReadAsStringAsync();
                Newtonsoft.Json.Linq.JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>( content );
                accessToken = jwtDynamic.Value<string>( "access_token" );
                if ( accessToken != null && accessToken != "" ) {
                    Global.token = accessToken;
                    //Here get the user info
                    var result = HelperClass.GetStringRecord( $"{Global.WebApiUrl}/api/user/GetUserInfoMobile?username={EntryUserName.Text}" );

                    userinfo_mobile_v userinfo = JsonConvert.DeserializeObject<userinfo_mobile_v>( result );

                    Global.LoggedInUserId = userinfo.UserId;
                    Global.GroupId = userinfo.group_id;
                    Global.ParentId = userinfo.parent_id;
                    Global.ParentName = userinfo.parent_name;
                    //await DisplayAlert("Login", "Login Successful", "ok");
                    if ( Global.GroupId == 3 ) {
                        LoginButton.IsEnabled = true;
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
    }
}