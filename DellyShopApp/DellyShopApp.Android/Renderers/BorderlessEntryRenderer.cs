using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DellyShopApp.Droid.Renderers;
using DellyShopApp.Renderers;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessBorderlessEntryRenderer))]
namespace DellyShopApp.Droid.Renderers
{
    public class BorderlessBorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessBorderlessEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}