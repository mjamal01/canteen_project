using DellyShopApp.Views.CustomView;
using DellyShopApp.Views.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void OrderInfoClick(object sender, EventArgs e)
        {
            if (!(sender is PancakeView stack)) return;
            switch (stack.ClassId)
            {
                case "MyOder":
                    OpenPage(new MyOrderPage());
                    break;

                case "MyFav":
                    OpenPage(new MyFavoritePage());
                    break;

                case "LastView":
                    OpenPage(new LastViewPage());
                    break;

                case "MyComments":
                    OpenPage(new MyCommentsPage());
                    break;

                case "Notifications":
                    OpenPage(new NotificationPage());
                    break;

                case "Settings":
                    OpenPage(new SettingsPage());
                    break;
            }
        }

        private void OpenPage(Page page)
        {
            Navigation.PushAsync(page);
        }
    }
}