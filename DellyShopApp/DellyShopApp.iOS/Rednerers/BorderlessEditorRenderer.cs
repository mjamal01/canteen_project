
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using DellyShopApp.iOS.Rednerers;
using DellyShopApp.Renderers;
[assembly:ExportRenderer(typeof(BorderlessEditor),typeof(BorderlessEditorRenderer))]
namespace DellyShopApp.iOS.Rednerers
{
  public  class BorderlessEditorRenderer : EditorRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control == null) return;
            Control.Layer.BorderWidth = 0;
            
        }
    }
}