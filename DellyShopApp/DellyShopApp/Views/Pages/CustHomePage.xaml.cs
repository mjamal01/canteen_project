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
    public partial class CustHomePage {
        public CustHomePage() {
            InitializeComponent();
            ViewModel = new CustHomeViewModel();
        }
        public CustHomeViewModel ViewModel {
            get => this.BindingContext as CustHomeViewModel;
            set => this.BindingContext = value;
        }

        private void FilterLayoutVisible(object sender, EventArgs e) {

        }
        protected override void OnAppearing() {
            base.OnAppearing();
            ViewModel.LoadChildrens();
            ViewModel.LoadBalanceCommand.Execute( null );
        }
    }
}