using DellyShopApp.CommonData;
using DellyShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DellyShopApp.ViewModel {
    public class SignupParentViewModel : BaseVm {

        public Parent parent { get; set; }

        private string iqamaId;
        public string IqamaId {
            get => iqamaId;
            set {
                iqamaId = value;
                OnPropertyChanged( nameof( IqamaId ) );
            }
        }

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

        private string phone;
        public string Phone {
            get => phone;
            set {
                phone = value;
                OnPropertyChanged( nameof( Phone ) );
            }
        }



        public ICommand ParentSignupCommand { get; set; }
        public SignupParentViewModel() {
            parent = new Parent();
            ParentSignupCommand = new Command( OnParentSignup );
        }

        private void OnParentSignup() {

            if ( string.IsNullOrEmpty( IqamaId ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter IqamaID.", "Back" );
                return;
            }
            if ( string.IsNullOrEmpty( FullName ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter full name.", "Back" );
                return;
            }
            if ( string.IsNullOrEmpty( Email ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter email.", "Back" );
                return;
            }
            if ( string.IsNullOrEmpty( Phone ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter phone number.", "Back" );
                return;
            }


            try {

                List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("NationalIqamaId", IqamaId),
                    new KeyValuePair<string, string>("name", FullName),
                    new KeyValuePair<string, string>("email", Email),
                    new KeyValuePair<string, string>("phone", Phone),
                };

                string result = HelperClass.PostRecord( $"{Global.WebApiUrl}/api/parent/Add", pairs );
                Application.Current.MainPage.DisplayAlert( "Signup", result, "OK" );
            } catch ( Exception ex ) {
                Console.WriteLine( ex.StackTrace );
            }

        }
    }
}
