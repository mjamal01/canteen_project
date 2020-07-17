using DellyShopApp.Models;
using DellyShopApp.Views.CustomView;
using DellyShopApp.Views.Pages.Base;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCommentsPage : BasePage
    {
        private readonly List<CommentClass> _comments = new List<CommentClass>();
        private int count;

        public MyCommentsPage()
        {
            InitializeComponent();

            foreach (var product in ProcutListModel)
            {
                _comments.Add(new CommentClass
                {
                    Comment = CommentList[count],
                    Product = product
                });
                count += 1;
            }

            Comments.ItemsSource = _comments;
        }

        private struct CommentClass
        {
            public ProductListModel Product { get; set; }
            public CommentModel Comment { get; set; }
        }

        private async void ClickCommand(object sender, EventArgs e)
        {
            if (!(sender is PancakeView pancake)) return;
            if (!(pancake.Parent is StackLayout stack)) return;
            if (!(stack.BindingContext is CommentClass item)) return;
            await Navigation.PushAsync(new CommentsPage(item.Product));
        }

        private async void ClickItem(object sender, EventArgs e)
        {
            if (!(sender is PancakeView pancake)) return;
            if (!(pancake.BindingContext is ProductListModel item)) return;
            await Navigation.PushAsync(new ProductDetail(item));
        }
    }
}