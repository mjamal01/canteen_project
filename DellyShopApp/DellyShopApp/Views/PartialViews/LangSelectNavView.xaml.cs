using DellyShopApp.Helpers;
using DellyShopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.PartialViews {
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class LangSelectNavView : StackLayout {
        private string[] languages = { "English", "العربية" };
        bool isModalpage = true;
        public LangSelectNavView() {
            InitializeComponent();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                if ( isModalpage )
                    Navigation.PopModalAsync();
                else
                    Navigation.PopAsync();
            };

            BackButton.GestureRecognizers.Add( tapGestureRecognizer );
            CheckLang();
        }

        private void CheckLang() {
            if ( Settings.SelectLanguage == "ar" ) {
                lblLanguage.Text = languages[0];
            } else {
                lblLanguage.Text = languages[1];
            }
        }

        public static BindableProperty IsModalpageProperty = BindableProperty.Create(
            propertyName: nameof( IsModalpage ),
            returnType: typeof( bool ),
            declaringType: typeof( LangSelectNavView ),
            defaultValue: true, propertyChanged: (bindable, oldValue, newValue) => {
                var control = ( LangSelectNavView ) bindable;
                control.IsModalpage = ( bool ) newValue;
            } );

        public bool IsModalpage {
            get => ( bool ) GetValue( IsModalpageProperty );
            set {
                SetValue( IsModalpageProperty, value );
                isModalpage = value;
            }
        }

        public static BindableProperty BackButtonVisibleroperty = BindableProperty.Create(
             propertyName: nameof( BackButtonVisibler ),
             returnType: typeof( bool ),
             declaringType: typeof( LangSelectNavView ),
             defaultValue: true, propertyChanged: (bindable, oldValue, newValue) => {
                 var control = ( LangSelectNavView ) bindable;
                 control.BackButtonVisibler = ( bool ) newValue;
             } );

        public bool BackButtonVisibler {
            get => ( bool ) GetValue( BackButtonVisibleroperty );
            set {
                SetValue( BackButtonVisibleroperty, value );
                BackButton.IsVisible = value;
            }
        }

        public static BindableProperty TitleProperty = BindableProperty.Create(
           propertyName: nameof( NavigationTitle ),
           returnType: typeof( string ),
           declaringType: typeof( LangSelectNavView ),
           defaultValue: string.Empty, propertyChanged: (bindable, oldValue, newValue) => {
               var control = ( LangSelectNavView ) bindable;
               control.NavigationTitle = newValue.ToString();
           } );

        public string NavigationTitle {
            get => ( string ) GetValue( TitleProperty );
            set {
                SetValue( TitleProperty, value );
                Title.Text = value;
            }
        }

        void BackButtonClick(System.Object sender, System.EventArgs e) {
            Navigation.PopAsync();
        }

        private void ChangeLangTabbed(object sender, EventArgs e) {
            AppServices.SelectLanguage();
        }
    }
}