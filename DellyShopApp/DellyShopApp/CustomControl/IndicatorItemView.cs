
using System.ComponentModel;

namespace DellyShopApp.CustomControl
{
    public class IndicatorItemView : CircleFrame
    {
        public IndicatorItemView()
        {
            Size = 10;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static void Preserve()
        {
        }
    }
}
