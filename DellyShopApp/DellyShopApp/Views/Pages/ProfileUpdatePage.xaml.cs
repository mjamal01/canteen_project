using DellyShopApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class ProfileUpdatePage : ContentPage {
        public ProfileUpdatePage() {
            InitializeComponent();
            ViewModel = new ProfileUpdateViewModel();
        }

        public ProfileUpdateViewModel ViewModel {
            get => this.BindingContext as ProfileUpdateViewModel;
            set => this.BindingContext = value;
        }
    }
}