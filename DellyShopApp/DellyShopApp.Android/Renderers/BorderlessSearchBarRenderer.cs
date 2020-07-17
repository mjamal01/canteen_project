using Android.Content;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DellyShopApp.Droid.Renderers;
using DellyShopApp.Renderers;
[assembly: ExportRenderer(typeof(BorderlessSearchBar), typeof(BorderlessSearchBarRenderer))]
namespace DellyShopApp.Droid.Renderers
{
    public class BorderlessSearchBarRenderer : SearchBarRenderer
    {
        public BorderlessSearchBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var plateId = Resources.GetIdentifier("android:id/search_plate", null, null);
                var plate = Control.FindViewById(plateId);
                plate.SetBackgroundColor(Android.Graphics.Color.Transparent);

               
            }
        }
    }
}