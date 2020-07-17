using System;
using System.Collections.Generic;
using DellyShopApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectCreditCardPage
    {
        private readonly List<CrediCardModel> _crediCard = new List<CrediCardModel>();
        public SelectCreditCardPage()
        {
            _crediCard.Add(new CrediCardModel
            {
                CardName = "Home Card",
                CardNumber = "1256 **** **** 4855",
                Expiration = "12/22",
                CardColor = "#699BC1"
            });
            _crediCard.Add(new CrediCardModel
            {
                CardName = "Work Card",
                CardNumber = "5686 **** **** 5245",
                Expiration = "12/24",
                CardColor = "#54347E"
            });
            _crediCard.Add(new CrediCardModel
            {
                CardName = "Web Card",
                CardNumber = "1256 **** **** 7986",
                Expiration = "12/21",
                CardColor = "#68C277"
            });
            InitializeComponent();
            CarouselView.ItemsSource = _crediCard;
        }

        private void AddCardClick(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddNewCardPage(), true);
        }

        private void BackButton(object sender, EventArgs e)
        {
            Navigation.PopAsync(true);
        }

        private async void ContinueOrderButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SuccessPage());
        }
    }
}