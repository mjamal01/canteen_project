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
        public AddChildPage(IndividualChildDetail vm = null) {
            InitializeComponent();
            ViewModel = new AddChildViewModel(vm);
        }

        public AddChildViewModel ViewModel {
            get => this.BindingContext as AddChildViewModel;
            set => this.BindingContext = value;
        }
    }
}