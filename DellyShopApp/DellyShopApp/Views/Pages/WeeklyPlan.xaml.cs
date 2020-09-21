using DellyShopApp.Extensions;
using DellyShopApp.Models;
using DellyShopApp.ViewModel;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class WeeklyPlan : ContentPage {
        public ObservableCollection<ProductListWithlimit> WeekPlan { get; set; } = null;


        public WeeklyPlan(List<ProductListWithlimit> weekPlan) {

            InitializeComponent();
            BindingContext = this; 
            FilterList( weekPlan );
        }

        private void FilterList(List<ProductListWithlimit> weekPlan) {

            //f.Remove(t => t. )
            //weekPlan.ForEach( f => f.Where(t => t.Count > 0 ? true : !f.Remove( t ) )  );
            this.WeekPlan = weekPlan.ToObservableCollection();  //weekPlan.FindAll( t => t.ToList().FindAll( f => f.Count > 0 ).Count > 0 ).ToObservableCollection();
            OnPropertyChanged( nameof( WeekPlan ) );
        }
    }
}