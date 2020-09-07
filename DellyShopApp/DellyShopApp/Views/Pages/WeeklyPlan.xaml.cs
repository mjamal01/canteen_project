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
        public List<ProductListWithlimit> WeekPlan { get; set; } = null;


        public WeeklyPlan(List<ProductListWithlimit> weekPlan) {

            InitializeComponent();
            this.WeekPlan = weekPlan;
            BindingContext = this;

        }
    }
}