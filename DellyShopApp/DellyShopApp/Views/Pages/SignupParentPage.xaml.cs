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
    public partial class SignupParentPage : ContentPage {
        public SignupParentPage() {
            InitializeComponent();
            ViewModel = new SignupParentViewModel();
        }

        public SignupParentViewModel ViewModel {
            get => this.BindingContext as SignupParentViewModel;
            set => this.BindingContext = value;
        }
    }
}