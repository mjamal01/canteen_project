using DellyShopApp.CommonData;
using DellyShopApp.Extensions;
using DellyShopApp.Models;
using DellyShopApp.Services;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
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


        private MediaFile childImageMediaFile = null;
        private IndividualChildDetail editChild = null;
        public ICommand PickImageCommand { get; set; }
        public ICommand AddChildCommand { get; set; }
        public AddChildViewModel(IndividualChildDetail vm = null) {
            AddChildCommand = new Command( OnAddChild );
            PickImageCommand = new Command( OnPickImage );
            editChild = vm;

            if ( vm != null ) {

                UniqueId = vm.UniqueRef;
                FullName = vm.Name;
                Email = "";
                Phone = "";
                Address = "Hello hello";
            }

            UniqueId = "123123";
            FullName = "Hamza";
            Email = "hamza@hamza.com";
            Phone = "923105499567";
            Address = "Hello hello";

        }

        private async void OnPickImage(object obj) {
            childImageMediaFile = await AppServices.PickImageFromPhone();

            if ( childImageMediaFile == null ) {

                IsImageSelected = false;
                ChildImage = null;

            } else {

                IsImageSelected = true;
                ChildImage = childImageMediaFile.GetImageSource();
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
                var content = new MultipartFormDataContent {
                    { new StringContent( UniqueId ), "UniqueRef" },
                    { new StringContent( FullName ), "name" },
                    { new StringContent( Phone ), "phone" },
                    { new StringContent( Email ), "email" },
                    { new StringContent( Address ), "address" },
                    { new StringContent( "1" ), "school_Id" },
                    { new StringContent( Global.ParentId.ToString() ), "parent_id" }
                };
                if ( childImageMediaFile != null ) {
                    var file = childImageMediaFile.GetByteArray();
                    content.Add( new ByteArrayContent( file, 0, file.Length ), "avatar", "avatar.jpg" );
                }

                if ( editChild == null ) {
                    result = HelperClass.PostRecord( $"https://pos2.dndaims.net/api/cust/add", content );
                } else {

                    //content.Add( new KeyValuePair<string, string>( "id", editChild.Id.ToString() ) );

                    result = HelperClass.PostRecord( $"https://pos2.dndaims.net/api/cust/update", content );
                }

                Application.Current.MainPage.DisplayAlert( "Added", result, "OK" );
            } catch ( Exception ex ) {
                Console.WriteLine( ex.StackTrace );
            }

        }
    }
}
