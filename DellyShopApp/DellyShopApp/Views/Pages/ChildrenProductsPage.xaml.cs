using DellyShopApp.Models;
using DellyShopApp.ViewModel;
using DellyShopApp.Views.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class ChildrenProductsPage {
        public ChildrenProductsPage(ChildWithProducts vm) {
            InitializeComponent();
            ViewModel = new ChildrenProductsViewModel( vm );
        }

        public ChildrenProductsViewModel ViewModel {
            get => this.BindingContext as ChildrenProductsViewModel;
            set => this.BindingContext = value;
        }
    }
}