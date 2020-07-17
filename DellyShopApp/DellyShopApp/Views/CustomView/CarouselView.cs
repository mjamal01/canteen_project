using DellyShopApp.Processors;
using System.ComponentModel;
namespace DellyShopApp.Views.CustomView
{
    public class CarouselView : CardsView
    {
        public CarouselView() : this(new BaseCarouselFrontViewProcessor(), new BaseCarouselBackViewProcessor())
        {
        }

        public CarouselView(ICardProcessor frontViewProcessor, ICardBackViewProcessor backViewProcessor) : base(frontViewProcessor, backViewProcessor)
        {
            IsClippedToBounds = true;
        }

        protected override double DefaultMoveSizePercentage => .3;

        protected override bool DefaultIsCyclical => true;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static void Preserve()
        {
        }
    }
}
