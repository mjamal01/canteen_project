using DellyShopApp.Models;
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
    public partial class AddChildPage : ContentPage {
        public AddChildPage(ChildWithProducts vm = null) {
            InitializeComponent();
            ViewModel = new AddChildViewModel( vm );
        }

        public AddChildViewModel ViewModel {
            get => this.BindingContext as AddChildViewModel;
            set => this.BindingContext = value;
        }

        private void OnSchoolChanged(object sender, EventArgs e) {
            ViewModel.SchoolChangedCommand.Execute( schoolsPkr.SelectedItem );
        }
    }
}