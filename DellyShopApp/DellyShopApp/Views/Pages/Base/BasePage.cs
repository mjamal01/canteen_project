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


        public ObservableCollection<NotificationModel> NotificationList { get; set; } = new ObservableCollection<NotificationModel>();
        public ObservableCollection<ProductListModel> ProcutListModel { get; set; } = new ObservableCollection<ProductListModel>();
        //Here add a list which will be filled from WebApi having information of all the transactions of a parent
        public ObservableCollection<cant_parent_cash_trans> transactions { get; set; } = new ObservableCollection<cant_parent_cash_trans>();

        //Here fetch the list of children belonging to this parent  

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

        public BasePage() {

            NavigationPage.SetHasNavigationBar( this, false );
            this.FlowDirection = Settings.SelectLanguage == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

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