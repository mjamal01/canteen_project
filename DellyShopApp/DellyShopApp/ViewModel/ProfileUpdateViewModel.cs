using DellyShopApp.CommonData;
using DellyShopApp.Extensions;
using DellyShopApp.Models;
using DellyShopApp.Services;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DellyShopApp.ViewModel {
    public class ProfileUpdateViewModel : BaseVm {
        public ParentProfile parentProfile { get; set; }

        private string aqamaId;
        public string AqamaId {
            get => aqamaId;
            set {
                aqamaId = value;
                OnPropertyChanged( nameof( AqamaId ) );
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



        public ICommand ParentUpdateCommand { get; set; }
        public ProfileUpdateViewModel() {
            parentProfile = RestService.GetParentProfile();

            FullName = parentProfile.Name;
            AqamaId = parentProfile.NationalIqamaId;
            Phone = parentProfile.Phone;
            Email = parentProfile.Email;

            ParentUpdateCommand = new Command( OnParentUpdate );
        }

        private void OnParentUpdate() {

            if ( string.IsNullOrEmpty( AqamaId ) || !AppServices.IsValidAqamaId( AqamaId ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter a valid AqamaID and try again.", "Back" );
                return;
            }
            if ( string.IsNullOrEmpty( FullName ) || !AppServices.IsValidFullName( FullName ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter a valid name and try again.", "Back" );
                return;
            }
            if ( string.IsNullOrEmpty( Email ) || !AppServices.IsValidEmail( Email ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter a valid email address.", "Back" );
                return;
            }
            if ( string.IsNullOrEmpty( Phone ) || !AppServices.IsValidPhoneNumber( Phone ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter a valid phone number. Must be start with 00 and 14 characters in length.", "Back" );
                return;
            }


            try {

                List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("id", Global.ParentId.ToString()),
                    new KeyValuePair<string, string>("NationalIqamaId", AqamaId),
                    new KeyValuePair<string, string>("name", FullName),
                    new KeyValuePair<string, string>("email", Email),
                    new KeyValuePair<string, string>("phone", Phone),
                };

                string result = HelperClass.PutRecord( $"{Global.WebApiUrl}/api/parent/updateprofile", pairs );

                RestService.GetUserInfoMobile( Email, true );
                RestService.GetParentProfile( true );
                Application.Current.MainPage.DisplayAlert( "Result", result, "OK" );
                Application.Current.MainPage.Navigation.PopAsync();
            } catch ( Exception ex ) {

                Application.Current.MainPage.DisplayAlert( "Error", "Unable to update profile. Please try again later", "Okay" );
                Console.WriteLine( ex.StackTrace );
            }

        }
    }
}
