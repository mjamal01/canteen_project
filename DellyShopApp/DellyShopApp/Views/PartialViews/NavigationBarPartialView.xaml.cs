using System;
using DellyShopApp.Languages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.PartialViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationBarPartialView
    {
        bool isModalpage = true;
        public NavigationBarPartialView()
        {
            InitializeComponent();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                if (isModalpage)
                    Navigation.PopModalAsync();
                else
                    Navigation.PopAsync();
            };

            BackButton.GestureRecognizers.Add(tapGestureRecognizer);
        }

        public static BindableProperty FavVisibleProperty = BindableProperty.Create(
  propertyName: nameof(FavVisible),
  returnType: typeof(bool),
  declaringType: typeof(NavigationBarPartialView),
  defaultValue: true, propertyChanged: (bindable, oldValue, newValue) =>
  {
      var control = (NavigationBarPartialView)bindable;
      control.FavVisible = (bool)newValue;
  });
        public bool FavVisible
        {
            get => (bool)GetValue(FavVisibleProperty);
            set
            {
                SetValue(FavVisibleProperty, value);
                favImage.IsVisible = value;
            }
        }


        public static BindableProperty IsModalpageProperty = BindableProperty.Create(
     propertyName: nameof(IsModalpage),
     returnType: typeof(bool),
     declaringType: typeof(NavigationBarPartialView),
     defaultValue: true, propertyChanged: (bindable, oldValue, newValue) =>
     {
         var control = (NavigationBarPartialView)bindable;
         control.IsModalpage = (bool)newValue;
     });

        public bool IsModalpage
        {
            get => (bool)GetValue(IsModalpageProperty);
            set
            {
                SetValue(IsModalpageProperty, value);
                isModalpage = value;
            }
        }

        public static BindableProperty BackButtonVisibleroperty = BindableProperty.Create(
     propertyName: nameof(BackButtonVisibler),
     returnType: typeof(bool),
     declaringType: typeof(NavigationBarPartialView),
     defaultValue: true, propertyChanged: (bindable, oldValue, newValue) =>
     {
         var control = (NavigationBarPartialView)bindable;
         control.BackButtonVisibler = (bool)newValue;
     });

        public bool BackButtonVisibler
        {
            get => (bool)GetValue(BackButtonVisibleroperty);
            set
            {
                SetValue(BackButtonVisibleroperty, value);
                BackButton.IsVisible = value;
            }
        }

        public static BindableProperty TitleProperty = BindableProperty.Create(
       propertyName: nameof(NavigationTitle),
       returnType: typeof(string),
       declaringType: typeof(NavigationBarPartialView),
       defaultValue: string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
       {
           var control = (NavigationBarPartialView)bindable;
           control.NavigationTitle = newValue.ToString();
       });

        public string NavigationTitle
        {
            get => (string)GetValue(TitleProperty);
            set
            {
                SetValue(TitleProperty, value);
                Title.Text = value;
            }
        }
        void BackButtonClick(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}