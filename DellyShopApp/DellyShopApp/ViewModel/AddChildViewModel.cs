using DellyShopApp.CommonData;
using DellyShopApp.Extensions;
using DellyShopApp.Models;
using DellyShopApp.Services;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DellyShopApp.ViewModel {
    public class AddChildViewModel : BaseVm {

        public ObservableCollection<School> Schools { get; set; } = new ObservableCollection<School>();
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

        private int childId;
        public int ChildId {
            get => childId;
            set {
                childId = value;
                OnPropertyChanged( nameof( ChildId ) );
            }
        }

        private School schoolDetail = null;
        public School SchoolDetail {
            get => schoolDetail;
            set {
                schoolDetail = value;
                OnPropertyChanged( nameof( SchoolDetail ) );
            }
        }


        private MediaFile childImageMediaFile = null;
        private ChildWithProducts editChild = null;
        public ICommand PickImageCommand { get; set; }
        public ICommand AddChildCommand { get; set; }
        public ICommand SchoolChangedCommand { get; set; }
        public AddChildViewModel(ChildWithProducts vm = null) {
            AddChildCommand = new Command( OnAddChild );
            PickImageCommand = new Command( OnPickImage );
            SchoolChangedCommand = new Command<School>( payLoad => SchoolDetail = payLoad );
            editChild = vm;
            LoadSchoolList();
            if ( vm != null ) {

                if ( vm.Avatar != null ) {
                    IsImageSelected = true;
                    ChildImage = vm.Avatar;
                }

                SchoolDetail = Schools.FirstOrDefault( t => t.SchoolId == vm.SchoolId );
                ChildId = vm.Id;
                UniqueId = vm.UniqueRef;
                FullName = vm.Name;
                Email = vm.Email;
                Phone = vm.Phone;
                Address = vm.Address;

            } else {

                if ( Global.DebugMode ) {
                    UniqueId = "123123";
                    FullName = "Hamza";
                    Email = "hamza@hamza.com";
                    Phone = "923105499567";
                    Address = "Hello hello";
                }

            }

        }

        private void LoadSchoolList() {
            var list = RestService.GetSchoolsList();
            if ( list != null && list.Count > 0 ) {
                Schools = list;
            } else {
                Schools = null;
            }
        }

        private async void OnPickImage() {
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

            if ( string.IsNullOrEmpty( UniqueId ) || !AppServices.IsValidAqamaId( UniqueId ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter IqamaID.", "Back" );
                return;
            }

            if ( string.IsNullOrEmpty( FullName ) || !AppServices.IsValidFullName( FullName ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter full name.", "Back" );
                return;
            }

            if ( string.IsNullOrEmpty( Email ) || !AppServices.IsValidEmail( Email ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter email.", "Back" );
                return;
            }

            if ( string.IsNullOrEmpty( Phone ) || !AppServices.IsValidPhoneNumber( Phone ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter phone number.", "Back" );
                return;
            }

            if ( string.IsNullOrEmpty( Address ) ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please enter address.", "Back" );
                return;
            }

            if ( SchoolDetail == null ) {
                Application.Current.MainPage.DisplayAlert( "Invalid", "Please select school and try again.", "Back" );
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
                    { new StringContent( SchoolDetail.SchoolId.ToString() ), "school_Id" },
                    { new StringContent( Global.ParentId.ToString() ), "parent_id" }
                };

                if ( childImageMediaFile != null ) {

                    var file = childImageMediaFile.GetByteArray();
                    if ( ( long ) file.Length > Global.MaxPhotoSize ) {
                        long num = Global.MaxPhotoSize / 1048576L;
                        Application.Current.MainPage.DisplayAlert( "Invalid", string.Format( "Please select image less than {0} mb", num ), "Back" );
                        return;
                    }

                    content.Add( new ByteArrayContent( file, 0, file.Length ), "avatar", "avatar.jpg" );
                }

                if ( editChild == null ) {
                    result = HelperClass.SendRecord( $"https://pos2.dndaims.net/api/cust/add", content );
                } else {

                    //content.Add( new KeyValuePair<string, string>( "id", editChild.Id.ToString() ) );
                    content.Add( new StringContent( ChildId.ToString() ), "id" );
                    result = HelperClass.SendRecord( $"https://pos2.dndaims.net/api/cust/update", content, "PUT" );
                }
                RestService.GetChildrenSchoolsList( true );
                RestService.GetChildrenMoneyAndProductsDetail( true );
                Application.Current.MainPage.DisplayAlert( "Result", result, "OK" );
                App.Current.MainPage.Navigation.PopAsync();
            } catch ( Exception ex ) {
                Console.WriteLine( ex.StackTrace );
                Application.Current.MainPage.DisplayAlert( "Error", ex.Message, "OK" );
            }

        }
    }
}
