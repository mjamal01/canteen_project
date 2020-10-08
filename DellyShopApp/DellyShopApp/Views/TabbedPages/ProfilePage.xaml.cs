using DellyShopApp.Services;
using DellyShopApp.Views.CustomView;
using DellyShopApp.Views.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.TabbedPages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class ProfilePage {


        private string fullName;
        public string FullName {
            get => fullName;
            set {
                fullName = value;
                OnPropertyChanged( nameof( FullName ) );
            }
        }

        private string email;
        public string Email {
            get => email;
            set {
                email = value;
                OnPropertyChanged( nameof( Email ) );
            }
        }


        public ProfilePage() {
            InitializeComponent();
            BindingContext = this;
        }

        private void OrderInfoClick(object sender, EventArgs e) {
            if ( !( sender is PancakeView stack ) )
                return;
            switch ( stack.ClassId ) {
                case "Personalize":
                    OpenPage( new ProfileUpdatePage() );
                    break;

                case "MyFav":
                    OpenPage( new MyFavoritePage() );
                    break;

                case "LastView":
                    OpenPage( new LastViewPage() );
                    break;

                case "MyComments":
                    OpenPage( new MyCommentsPage() );
                    break;

                case "Notifications":
                    OpenPage( new NotificationPage() );
                    break;

                case "Settings":
                    OpenPage( new SettingsPage() );
                    break;
            }
        }

        private void OpenPage(Page page) {
            Navigation.PushAsync( page );
        }

        private void OnLogout(object sender, EventArgs e) {
            Application.Current.MainPage = new NavigationPage( new LoginPage() );
        }
        protected override void OnAppearing() {
            base.OnAppearing();

            var profile = RestService.GetParentProfile();
            FullName = profile.Name;
            Email = profile.Email;
        }
    }
}