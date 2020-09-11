using DellyShopApp.CommonData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class ForgotPasswordPage : ContentPage {
        public ForgotPasswordPage() {
            InitializeComponent();
            BindingContext = this;
            if (Global.DebugMode) {
                EmailEntry.Text = "Hroxiin@gmail.com";
            }
        }

        private async void SubmitClick(object sender, EventArgs e) {
            SubmitButton.IsEnabled = false;
            if ( string.IsNullOrEmpty( EmailEntry.Text ) ) {
                await DisplayAlert( "Error", "Enter email address.", "ok" );
                SubmitButton.IsEnabled = true;
                return;
            }

            var username = EmailEntry.Text;
            //https://pos2.dndaims.net/api/parent/ForgotPassword?email=msajjadh@gmail.com
            try {

                var response = HelperClass.SendRecord( $"{Global.WebApiUrl}/api/parent/ForgotPassword?email={username}", new MultipartFormDataContent() );

                await DisplayAlert( "Result", response, "Okay" );

            } catch ( Exception ) {
                await DisplayAlert( "Invalid", "Provided email is incorrect", "Okay" ); 
            }

            SubmitButton.IsEnabled = true;
        }
    }
}