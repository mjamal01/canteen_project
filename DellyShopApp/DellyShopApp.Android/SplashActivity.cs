using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;

namespace DellyShopApp.Droid {
    // @style/MyTheme.Splash
    [Activity( Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true )]
    public class SplashActivity : Activity {
        static readonly string TAG = "X:" + typeof( SplashActivity ).Name;
        private ProgressBar progressBar;
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState) {
            base.OnCreate( savedInstanceState, persistentState );
            //progressBar = FindViewById<ProgressBar>( Resource.Id.splashProgressBar );
            Log.Debug( TAG, "SplashActivity.OnCreate" );
        }
        protected override void OnStart() {
            base.OnStart();
            SetContentView( Resource.Layout.SplashScreen );
        }

        // Launches the startup task
        protected override void OnResume() {
            base.OnResume();
            //SetContentView( Resource.Layout.SplashScreen );
            //progressBar = FindViewById<ProgressBar>( Resource.Id.splashProgressBar );

            Task startupWork = new Task( () => { SimulateStartup(); } );
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup() {
            Log.Debug( TAG, "Performing some startup work that takes a bit of time." );
            // Simulate a bit of startup work.
            Log.Debug( TAG, "Startup work is finished - starting MainActivity." );
            StartActivity( new Intent( Application.Context, typeof( MainActivity ) ) );
        }
    }
}