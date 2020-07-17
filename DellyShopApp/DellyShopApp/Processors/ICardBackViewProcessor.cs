
using System.Collections.Generic;
using DellyShopApp.Views.CustomView;
using Xamarin.Forms;
namespace DellyShopApp.Processors
{
    public interface ICardBackViewProcessor : ICardProcessor
    {
        void HandleCleanView(IEnumerable<View> views, CardsView cardsView);
    }
}
