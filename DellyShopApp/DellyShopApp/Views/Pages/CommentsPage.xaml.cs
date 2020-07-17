using DellyShopApp.Helpers;
using DellyShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentsPage
    {
        private readonly List<StartList> _startList = new List<StartList>();
        private readonly List<StartList> _filterStar = new List<StartList>();
        private readonly List<FilterModel> _filter = new List<FilterModel>();

        private readonly List<CommentModel> _comments = new List<CommentModel>();
        private bool filterLayout = false;
        public CommentsPage(ProductListModel product)
        {
            _startList.Add(new StartList
            {
                StarImg = FontAwesomeIcons.Star
            });
            _startList.Add(new StartList
            {
                StarImg = FontAwesomeIcons.Star
            });
            _startList.Add(new StartList
            {
                StarImg = FontAwesomeIcons.Star
            });
            _startList.Add(new StartList
            {
                StarImg = FontAwesomeIcons.Star
            });
            _startList.Add(new StartList
            {
                StarImg = FontAwesomeIcons.Star
            });
            _comments.Add(new CommentModel
            {
                Name = "Ufuk Sahin",
                CommentTime = "12/1/19",
                Id = 1,
                Rates = _startList
            });
            _comments.Add(new CommentModel
            {
                Name = "Hans Goldman",
                CommentTime = "11/1/19",
                Id = 2,
                Rates = _startList.Skip(0).ToList()
            });
            for (var i = 5; i >= 0; i--)
            {
                _filterStar = new List<StartList>();
                for (var j = 0; j <= i; j++)//*//**//***//
                {
                    Console.Write("*");//www.gorselprogramlama.com
                    _filterStar.Add(new StartList
                    {
                        StarImg = FontAwesomeIcons.Star
                    });
                }
                _filter.Add(new FilterModel
                {
                    startLists = _filterStar
                });
                Console.Write("\n");
            }
            InitializeComponent();
            this.BindingContext = product;
            CommentList.ItemsSource = _comments;
            filterStars.ItemsSource = _filter;
        }
        
        private async void BackButton(object sender, EventArgs e)
        {
          await Navigation.PopAsync();
        }

        private async void FilterLayoutVisible(object sender, EventArgs e)
        {
            filterLayout = filterLayout == false;
            FilterLayout.IsVisible = filterLayout;
            if (filterLayout)
                await FilterLayout.FadeTo(1, 300, Easing.CubicOut);
            else
                await FilterLayout.FadeTo(0, 300, Easing.CubicIn);
        }
    }
}