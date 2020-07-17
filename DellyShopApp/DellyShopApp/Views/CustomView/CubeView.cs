
using System.ComponentModel;
using DellyShopApp.Processors;
namespace DellyShopApp.Views.CustomView
{
    public class CubeView : CarouselView
    {
        public CubeView() : this(new BaseCubeFrontViewProcessor(), new BaseCubeBackViewProcessor())
        {
        }

        public CubeView(ICardProcessor frontViewProcessor, ICardBackViewProcessor backViewProcessor) : base(frontViewProcessor, backViewProcessor)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static void Preserve()
        {
        }
    }

}
