using DellyShopApp.CommonData;
using DellyShopApp.Models;
using DellyShopApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DellyShopApp.ViewModel {
    public class AddChildViewModel : BaseVm {


        private string uniqueId;
        public string UniqueId {
            get => uniqueId;
            set {
                uniqueId = value;
                OnPropertyChanged( nameof( UniqueId ) );
            }
        }

        private string address;
        public string Address {
            get => address;
            set {
                address = value;
                OnPropertyChanged( nameof( Address ) );
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

        private bool isImageSelected = false;
        public bool IsImageSelected {
            get => isImageSelected;
            set {
                isImageSelected = value;
                OnPropertyChanged( nameof( IsImageSelected ) );
            }
        } 

        private ImageSource childImage = null; 
        public ImageSource ChildImage {
            get => childImage;
            set {
                childImage = value;
                OnPropertyChanged( nameof( ChildImage ) );
            }
        }



        private IndividualChildDetail editChild = null;
        public ICommand PickImageCommand { get; set; }
        public ICommand AddChildCommand { get; set; }
        public AddChildViewModel(IndividualChildDetail vm =null) {
            AddChildCommand = new Command( OnAddChild );
            PickImageCommand = new Command( OnPickImage );
            editChild = vm;

            if( vm  != null) {

                UniqueId = vm.UniqueRef;
                FullName = vm.Name;
                Email = "";
                Phone = "";
                Address = "Hello hello";
            }

            //UniqueId = "123123";
            //FullName = "Hamza"; 
            //Email = "hamza@hamza.com";
            //Phone = "923105499567";
            //Address = "Hello hello";

        }

        private async void OnPickImage(object obj) {
            var image = await AppServices.PickImageFromPhone();
            if (image == null) {

                IsImageSelected = false;
                ChildImage = null;
            
            } else {

                IsImageSelected = true;
                ChildImage = image;
            }
        }

        private void OnAddChild() {

            if ( string.IsNullOrEmpty( UniqueId ) ) {
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
            if ( string.IsNullOrEmpty( Address ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter address.", "Back" );
                return;
            }


            try {
                string result = "";
                List <KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("UniqueRef", UniqueId),
                    new KeyValuePair<string, string>("name", FullName),
                    new KeyValuePair<string, string>("email", Email),
                    new KeyValuePair<string, string>("phone", Phone),
                    new KeyValuePair<string, string>("address", Address),
                    new KeyValuePair<string, string>("school_Id", "123"),
                    new KeyValuePair<string, string>("parent_id", Global.ParentId.ToString()),
                };

                if ( editChild == null) { 
                    result = HelperClass.PostRecord( $"https://pos2.dndaims.net/api/cust/add", pairs );
                } else {

                    //pairs.Add( new KeyValuePair<string, string>( "id", editChild.Id.ToString() ) );

                    result = HelperClass.PostRecord( $"https://pos2.dndaims.net/api/cust/update", pairs );
                }

                Application.Current.MainPage.DisplayAlert( "Added", result, "OK" );
            } catch ( Exception ex ) {
                Console.WriteLine( ex.StackTrace );
            }

        }
    }
}
