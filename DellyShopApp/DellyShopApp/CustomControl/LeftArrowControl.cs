using System.ComponentModel;
using Xamarin.Forms;
using static DellyShopApp.Resources.ResourcesInfo;
namespace DellyShopApp.CustomControl
{
    public class LeftArrowControl : ArrowControl
    {
        public LeftArrowControl()
        {
            IsRight = false;
            AbsoluteLayout.SetLayoutBounds(this, new Rectangle(0, .5, -1, -1));
        }

        protected override ImageSource DefaultImageSource => WhiteLeftArrowImageSource;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static void Preserve()
        {
        }
    }
}
