using System;
using System.Collections.Generic;
using DellyShopApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessPage
    {
        private List<ProductListModel> _procutListModel = new List<ProductListModel>();

        public SuccessPage()
        {
            _procutListModel.Add(new ProductListModel
            {
                Title = "iPhone 8 Plus Gold",
                Brand = "Apple",
                Id = 1,
                Image = "iphone",
                Price = 499,
                VisibleItemDelete = false
            });
            _procutListModel.Add(new ProductListModel
            {
                Title = "Grey Firozi Mesh",
                Brand = "ASIAN",
                Id = 3,
                Image = "shoesblack2",
                Price = 150,
                VisibleItemDelete = false
            });
            _procutListModel.Add(new ProductListModel
            {
                Title = "Presto Yellow",
                Brand = "Nike",
                Id = 2,
                Image = "shoesyellow",
                Price = 299,
                VisibleItemDelete = false
            });
            InitializeComponent();
            BasketItems.ItemsSource = _procutListModel;
        }

        private async void ContinueClick(object sender, EventArgs e)
        {
            //.Current.MainPage = new HomeTabbedPage();
            Application.Current.MainPage = new NavigationPage(new HomeTabbedPage());
        }
    }
}