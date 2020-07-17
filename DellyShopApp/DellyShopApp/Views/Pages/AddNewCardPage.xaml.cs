using System;
using System.ComponentModel;
using DellyShopApp.ViewModel;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class AddNewCardPage
    {
        public AddNewCardPage()
        {
            InitializeComponent();
            this.BindingContext = new CreditCardPageViewModel();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }

}