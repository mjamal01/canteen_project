using System;
using DellyShopApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DellyShopApp.Languages;
using Xamarin.Forms;
using DellyShopApp.Helpers;
using DellyShopApp.ParentsData.CashHandling;
using Newtonsoft.Json;
using DellyShopApp.ParentsData;
using DellyShopApp.CommonData;
using DellyShopApp.ViewModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using DellyShopApp.Annotations;
//Test comments
namespace DellyShopApp.Views.Pages.Base {
    public class BasePage : ContentPage, INotifyPropertyChanged {


        public ObservableCollection<NotificationModel> NotificationList = new ObservableCollection<NotificationModel>();
        public ObservableCollection<ProductListModel> ProcutListModel = new ObservableCollection<ProductListModel>();
        //Here add a list which will be filled from WebApi having information of all the transactions of a parent
        public ObservableCollection<cant_parent_cash_trans> transactions = new ObservableCollection<cant_parent_cash_trans>();

        //Here fetch the list of children belonging to this parent 

        static public ObservableCollection<IndividualChildDetail> ChildrenDetailList { get; set; } = new ObservableCollection<IndividualChildDetail>();

        static public decimal totalDebit = 0;
        static public decimal totalCredit = 0;
        static public int CurrentChildId = 0;
        static public int CurrentChildIndex = 0;
        static public int CurrentDayIndex = 0;
        static public int CurrentProductId = 0;

        public List<Category> CatoCategoriesList = new List<Category>();
        public List<Category> Carousel = new List<Category>();
        public List<StartList> StartList = new List<StartList>();
        public List<Category> CatoCategoriesDetail = new List<Category>();
        public List<CommentModel> CommentList = new List<CommentModel>();

        public double BaseTotalPrice = 0;
        public static void InitializeChildrenData() {
            var url = $"{Global.WebApiUrl}/api/parent/GetChildrenMoneyAndProductsDetail?parentId={Global.ParentId}";
            var result = HelperClass.GetRecord( url );
            ChildrenDetailList = JsonConvert.DeserializeObject<ObservableCollection<IndividualChildDetail>>( result );
        }

        public BasePage() {
            //InitializeChildrenData(); 

            Xamarin.Forms.NavigationPage.SetHasNavigationBar( this, false );
            this.FlowDirection = Settings.SelectLanguage == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

            NotificationList.Add( new NotificationModel {
                Title = AppResources.NotificatinTitle,
                SubTitle = AppResources.NotificationSubtitle,
                Description = AppResources.LoremIpsum,
                Id = 1,
                Image = "elecronics.jpeg",
                InstertedAt = DateTime.Now

            } );
            NotificationList.Add( new NotificationModel {

                Title = AppResources.NotificatinTitle,
                SubTitle = AppResources.NotificationSubtitle,
                Description = AppResources.LoremIpsum,
                Id = 2,
                Image = "shoes.jpg",
                InstertedAt = DateTime.Now

            } );
            ProcutListModel.Add( new ProductListModel {
                Title = AppResources.ProcutTitle,
                Brand = AppResources.ProductBrand,
                Id = 1,
                Image = "shoesBlack",
                Price = 362,
                VisibleItemDelete = false,
                ProductList = new string[] { "red1", "shoesBlack" }
            } );
            ProcutListModel.Add( new ProductListModel {
                Title = AppResources.ProcutTitle1,
                Brand = AppResources.ProductBrand1,
                Id = 2,
                Image = "grazy1",
                Price = 150,
                VisibleItemDelete = false,
                ProductList = new string[] { "garzy2", "grazy1" }
            } );
            ProcutListModel.Add( new ProductListModel {
                Title = AppResources.ProcutTitle2,
                Brand = AppResources.ProductBrand2,
                Id = 3,
                Image = "shoesyellow",
                Price = 299,
                VisibleItemDelete = false,
                ProductList = new string[] { "py_1", "shoesyellow" }
            } );
            foreach ( var item in ProcutListModel ) {
                BaseTotalPrice += item.Price;
            }
            CatoCategoriesList.Add( new Category {
                CategoryName = AppResources.Shoes,
                Image = "shoesCategory.png",
                Id = "1"
            } );
            CatoCategoriesList.Add( new Category {
                CategoryName = AppResources.Electronics,

                Image = "electronicCategory.png",
                Id = "2"
            } );
            CatoCategoriesList.Add( new Category {
                CategoryName = AppResources.Clothing,

                Image = "clothingCategory.png",
                Id = "3"
            } );
            StartList.Add( new StartList {
                StarImg = FontAwesomeIcons.Star
            } );
            StartList.Add( new StartList {
                StarImg = FontAwesomeIcons.Star
            } );
            StartList.Add( new StartList {
                StarImg = FontAwesomeIcons.Star
            } );
            StartList.Add( new StartList {
                StarImg = FontAwesomeIcons.Star
            } );
            StartList.Add( new StartList {
                StarImg = FontAwesomeIcons.Star
            } );
            CommentList.Add( new CommentModel {
                Name = "Ufuk Sahin",
                CommentTime = "12/1/19",
                Id = 1,
                Rates = StartList
            } );
            CommentList.Add( new CommentModel {
                Name = "Hans Goldman",
                CommentTime = "11/6/19",
                Id = 2,
                Rates = StartList.Skip( 0 ).ToList()
            } );
            CommentList.Add( new CommentModel {
                Name = "Jon Goodman",
                CommentTime = "12/8/19",
                Id = 3,
                Rates = StartList.Skip( 1 ).ToList()
            } );
            CatoCategoriesDetail.Add( new Category {
                Image = "shoes.jpg"
            } );
            CatoCategoriesDetail.Add( new Category {
                Image = "bestShoes.jpg"
            } );
            CatoCategoriesDetail.Add( new Category {
                Image = "bestofYear.jpg"
            } );
            Carousel.Add( new Category {
                Image = "shoes.jpg"
            } );
            Carousel.Add( new Category {
                Image = "clothing.jpg"
            } );
            Carousel.Add( new Category {
                Image = "elecronics.jpeg"
            } );
        }

        public void UpdateTransactions() {
            transactions.Clear();
            totalCredit = 0;
            totalDebit = 0;
            try {
                transactions = JsonConvert.DeserializeObject<ObservableCollection<cant_parent_cash_trans>>( Global.CashTransDetail );
                foreach ( var trans in transactions ) {
                    if ( trans.Debit > 0 ) {
                        trans.image = "ChildLogo.png";//Debit image. It will be child picture later
                        trans.AmountDescription = $"-{trans.Debit.ToString( "0.##" )}";
                    } else {
                        trans.image = "CreditCard.png";//Credit image. It can be credit card picture
                        trans.AmountDescription = $"+{trans.Credit.ToString( "0.##" )}";
                    }

                    totalDebit += trans.Debit;
                    totalCredit += trans.Credit;
                    trans.BalanceAmount = $"Balance = {trans.Balance.ToString( "0.##" )}, Total Debit = {totalDebit.ToString( "0.##" )}, Total Credit = {totalCredit.ToString( "0.##" )}";
                }
            } catch ( Exception ex ) {

            }
        }
        public void UpdateChildren() {
            //lsChildren.Clear();
            //var result = HelperClass.GetStringRecord($"{Global.WebApiUrl}/api/parent/GetChildrenList?parent_id={Global.ParentId}");
            //List<Children> lsChild = JsonConvert.DeserializeObject<List<Children>>(result);
            //int index = 0;
            //foreach (var child in lsChild)
            //{
            //    lsChildren.Add(new Child() { childName = child.name, CustomerId = (int)child.customer_id, ChildIndex = index, DailyCashLimit = child.DailyCashLimit });
            //    index++;
            //}

        }

    }
}