using DellyShopApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationDetail
    {
        private const double TextSpeed = 0.5;
        private double _parallaxLabelStartY;

        public NotificationDetail(NotificationModel notifModel)
        {
            InitializeComponent();

            BindingContext = notifModel;
            ParallaxScrollView.Scrolled += ParallaxScrollViewOnScrolled;
            Imagestack.Scale = 1.6;
            Imagestack.ScaleTo(1, 300, Easing.CubicInOut);
            TitleLabel.TranslateTo(0, 0, 400, Easing.CubicInOut);
            DateLabel.TranslateTo(0, 0, 450, Easing.CubicInOut);
            Textstack.TranslateTo(0, 0, 500, Easing.CubicInOut);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            // Init start position for parallax elements
            Imagestack.WidthRequest = width;
            Imagestack.TranslationY = ParalaxContainer.Height - Imagestack.Height; Imagestack.TranslationX = 0;

            //ParallaxLabel.TranslationX = ParalaxContainer.Width / 2 - ParallaxLabel.Width / 2;
            ParallaxLabel.TranslationY = _parallaxLabelStartY = ParalaxContainer.Height / 2 - ParallaxLabel.Height / 2;
        }

        /// <summary>
        /// sayfa scrol edildiğibde çalışır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParallaxScrollViewOnScrolled(object sender, ScrolledEventArgs e)
        {
            ParalaxTextAnimation(e.ScrollY);
        }

        /// <summary>
        /// parallax içindeki text animasyonu için
        /// </summary>
        /// <param name="scrollY"></param>
        private void ParalaxTextAnimation(double scrollY)
        {
            ParalaxAnimation(ParallaxLabel, scrollY, _parallaxLabelStartY, 0, ParalaxContainer.HeightRequest - ParallaxLabel.Height, TextSpeed);
        }

        /// <summary>
        /// parallax animayonu için gerekli kodları içerir.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="scrollY"></param>
        /// <param name="startPosition"></param>
        /// <param name="minPosition"></param>
        /// <param name="maxPosition"></param>
        /// <param name="speed"></param>
        private void ParalaxAnimation(View control,
                                      double scrollY,
                                      double startPosition,
                                      double minPosition,
                                      double maxPosition,
                                      double speed)
        {
            var newPosition = startPosition + scrollY * speed;
            if (newPosition > minPosition && newPosition < maxPosition)
            {
                control.TranslationY = newPosition;
            }
        }
    }
}