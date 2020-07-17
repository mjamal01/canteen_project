using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.PartialViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationBarWithHeaderControl : StackLayout
    {
        public NavigationBarWithHeaderControl(string title, bool backButtonVisible, bool isModalpage, bool ImageToolsVisible)
        {
            InitializeComponent();
            Title.Text = title;
            BackButton.IsVisible = backButtonVisible;
            favImage.IsVisible = ImageToolsVisible;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                if (isModalpage)
                    Navigation.PopModalAsync();
                else
                    Navigation.PopAsync();
            };

            BackButton.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}