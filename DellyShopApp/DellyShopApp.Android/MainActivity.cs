using System;
using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using DellyShopApp.Droid.Renderers;
using FFImageLoading.Forms.Platform;
using Xamarin.Forms;
namespace DellyShopApp.Droid {
    [Activity( Label = "KodmaxCanteenApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
        protected override void OnCreate(Bundle savedInstanceState) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            initFontScale();
            Xamarin.Essentials.Platform.Init( this, savedInstanceState );
            CachedImageRenderer.Init( enableFastRenderer: true );
            base.OnCreate( savedInstanceState );
            ///For Performance 
            Forms.SetFlags( "FastRenderers_Experimental" );

            AndroidEnvironment.UnhandledExceptionRaiser -= StoreLogger;
            AndroidEnvironment.UnhandledExceptionRaiser += StoreLogger;
            global::Xamarin.Forms.Forms.Init( this, savedInstanceState );
            CardsViewRenderer.Preserve();
            CachedImageRenderer.InitImageViewHandler();

            LoadApplication( new App() );
        }

        private void StoreLogger(object sender, RaiseThrowableEventArgs e) {
            Console.WriteLine( e.Exception );
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult( requestCode, permissions, grantResults );

            base.OnRequestPermissionsResult( requestCode, permissions, grantResults );
        }

        private void initFontScale() {
            Configuration configuration = Resources.Configuration;
            configuration.FontScale = ( float ) 1;
            //0.85 small, 1 standard, 1.15 big，1.3 more bigger ，1.45 supper big
            DisplayMetrics metrics = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics( metrics );
            metrics.ScaledDensity = configuration.FontScale * metrics.Density;
            BaseContext.Resources.UpdateConfiguration( configuration, metrics );
        }
    }
}