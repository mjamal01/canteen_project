using DellyShopApp.Languages;
using DellyShopApp.Models;
using DellyShopApp.Views.CustomView;
using DellyShopApp.Views.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
    {
        public HomePage()
        {
            ProcutListModel.Insert(0, new ProductListModel
            {
                Title = AppResources.ProcutTitle3,
                Brand = AppResources.ProductBrand3,

                Id = 4,
                Image = "iphone",
                Price = 499,
                VisibleItemDelete = false,
                ProductList = new string[] { "ip8_1", "ip8_2" }
            });

            InitializeComponent();
            CategoryList.ItemsSource = CatoCategoriesList;
            CarouselView.ItemsSource = Carousel;
            BestSellerList.ItemsSource = ProcutListModel;
            PreviousViewedList.ItemsSource = ProcutListModel;
            MostNews.FlowItemsSource = ProcutListModel;
        }

        private async void ProductDetailClick(object sender, EventArgs e)
        {
            if (!(sender is PancakeView pancake)) return;
            if (!(pancake.BindingContext is ProductListModel item)) return;
            await Navigation.PushAsync(new ProductDetail(item));
        }

        private async void ClickCategory(object sender, EventArgs e)
        {
            if (!(sender is StackLayout stack)) return;
            if (!(stack.BindingContext is Category ca)) return;
            await Navigation.PushAsync(new CategoryDetailPage(ca));
        }

    

       async void VireAllTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new BestSellerPage());
        }
    }
}