﻿
using DellyShopApp.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using DellyShopApp.Views.CustomView;
using Xamarin.Forms;
namespace DellyShopApp.Processors
{
    public interface ICardProcessor
    {
        void HandleInitView(IEnumerable<View> views, CardsView cardsView, AnimationDirection animationDirection);
        void HandlePanChanged(IEnumerable<View> views, CardsView cardsView, double xPos, AnimationDirection animationDirection, IEnumerable<View> inactiveViews);
        Task HandleAutoNavigate(IEnumerable<View> views, CardsView cardsView, AnimationDirection animationDirection, IEnumerable<View> inactiveViews);
        Task HandlePanReset(IEnumerable<View> views, CardsView cardsView, AnimationDirection animationDirection, IEnumerable<View> inactiveViews);
        Task HandlePanApply(IEnumerable<View> views, CardsView cardsView, AnimationDirection animationDirection, IEnumerable<View> inactiveViews);
    }
}
