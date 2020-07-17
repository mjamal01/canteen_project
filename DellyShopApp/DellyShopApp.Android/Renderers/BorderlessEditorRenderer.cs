using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DellyShopApp.Droid.Renderers;
using DellyShopApp.Renderers;

[assembly: ExportRenderer(typeof(BorderlessEditor), typeof(BorderlessEditorRenderer))]

namespace DellyShopApp.Droid.Renderers
{
    class BorderlessEditorRenderer : EditorRenderer
    {
        public BorderlessEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;

 
                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
            }
        }
    }
}