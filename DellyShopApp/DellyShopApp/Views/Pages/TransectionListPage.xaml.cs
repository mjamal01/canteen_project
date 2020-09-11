using DellyShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class TransectionListPage : ContentPage {
        public TransectionListPage(List<Transection> list) {
            InitializeComponent();
            listItems.ItemsSource = list;
            BindingContext = this;
        }
    }
}