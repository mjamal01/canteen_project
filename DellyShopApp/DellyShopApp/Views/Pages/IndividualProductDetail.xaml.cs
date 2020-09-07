using System;
using System.Collections.Generic;
using System.Linq;
using DellyShopApp.Helpers;
using DellyShopApp.Languages;
using DellyShopApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class IndividualProductDetail {
        int productCount;
        private readonly List<StartList> _startList = new List<StartList>();
        private readonly List<CommentModel> _comments = new List<CommentModel>();
        private readonly ProductListModel _products;
        public IndividualProductDetail(ProductListModel product) {
            _products = product;

            //_startList.Add(new StartList
            //{
            //    StarImg = FontAwesomeIcons.Star
            //});
            //_startList.Add(new StartList
            //{
            //    StarImg = FontAwesomeIcons.Star
            //});
            //_startList.Add(new StartList
            //{
            //    StarImg = FontAwesomeIcons.Star
            //});
            //_startList.Add(new StartList
            //{
            //    StarImg = FontAwesomeIcons.Star
            //});
            //_startList.Add(new StartList
            //{
            //    StarImg = FontAwesomeIcons.Star
            //});
            //_comments.Add(new CommentModel
            //{
            //    Name = "Ufuk Sahin",
            //    CommentTime = "12/1/19",
            //    Id = 1,
            //    Rates = _startList
            //});
            //_comments.Add(new CommentModel
            //{
            //    Name = "Hans Goldman",
            //    CommentTime = "11/1/19",
            //    Id = 2,
            //    Rates = _startList.Skip(0).ToList()
            //});
            this.BindingContext = product;
            InitializeComponent();

            //Get current Student
            int iCurrentStudent = CurrentChildId;
            //ChildrenDetailList.Where(item => item.customer_id == CurrentChildIndex).Select(data => data.;
            //Get current Product
            int iCurrentProduct = CurrentProductId;

            //Get current Day Index
            int iCurrentDayIndex = CurrentDayIndex;


            //Get the allowed quantity
            var individualChildDetail = ChildrenDetailList.Where( item => item.CustomerId == CurrentChildId ).Select( data => data ).First();
            string SevenDaysQuantity = individualChildDetail.ProductsList.Where( data => data.Id == CurrentProductId ).Select( info => info.DailyQty7Days ).First();
            string quantity = SevenDaysQuantity.Split( ',' ).GetValue( CurrentDayIndex ) as string;

            Random random = new Random();

            ProductCountLabel.Text = quantity.ToString();
            //starList.ItemsSource = _startList;
            //starListglobal.ItemsSource = _startList;

            //CommentList.ItemsSource = _comments;

            //MainScroll.Scrolled += MainScroll_Scrolled; 
        }
        private void PlusClick(object sender, EventArgs e) {
            if ( productCount >= 10 )
                return;
            ProductCountLabel.Text = ( ++productCount ).ToString();
        }
        private void MinusClick(object sender, EventArgs e) {
            if ( productCount == 0 )
                return;
            ProductCountLabel.Text = ( --productCount ).ToString();
        }
        private void MainScroll_Scrolled(object sender, ScrolledEventArgs e) {
            var height = Math.Round( Application.Current.MainPage.Height );
            var ycordinate = Math.Round( e.ScrollY );
            if ( ycordinate > ( height / 3 ) ) {
                NavbarStack.IsVisible = true;
                return;
            }

            NavbarStack.IsVisible = false;
        }

        private async void CommentsPageClick(object sender, EventArgs e) {
            await Navigation.PushAsync( new CommentsPage( _products ) );
        }

        void AddBasketButton(object sender, EventArgs e) {
            try {
                //int TargetQty = int.Parse(ProductCountLabel.Text);
                //Here get the target student record
                var studentRec = ChildrenDetailList.Where( item => item.CustomerId == CurrentChildId ).ToList().FirstOrDefault();
                var productRec = studentRec.ProductsList.Where( prod => prod.Id == _products.Id ).First();

                string[] arr = productRec.DailyQty7Days.Split( ',' );
                arr[CurrentDayIndex] = ProductCountLabel.Text;
                productRec.DailyQty7Days = String.Join( ",", arr );

                DisplayAlert( AppResources.Success, _products.Title + " " + productCount + " " + AppResources.AddedBakset, AppResources.Okay );
            } catch ( Exception ex ) {

            }
        }
    }
}