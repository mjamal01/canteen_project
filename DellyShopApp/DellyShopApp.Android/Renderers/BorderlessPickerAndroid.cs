using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DellyShopApp.Droid.Renderers;
using DellyShopApp.Renderers;

[assembly:ExportRenderer(typeof(BorderlessPicker),typeof(BorderlessPickerAndroid))]
namespace DellyShopApp.Droid.Renderers
{
    public class BorderlessPickerAndroid : PickerRenderer
    {
        public BorderlessPickerAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}