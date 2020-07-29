using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DellyShopApp.CustomControl {
    public class ProgressUtils {
        // Reference Values(Standard Pixel 1 Device)
        private const float refHeight = 1080;//1677;
        private const float refWidth = 632;//940;

        // Derived Proportinate Values
        private float deviceHeight = 1; // Initializing to 1
        private float deviceWidth = 1;  // Initializing to 1

        // Empty Constructor
        public ProgressUtils() { }

        // Setting Device Specific Values
        public void setDevice(int deviceHeight, int deviceWidth) {
            this.deviceHeight = deviceHeight;
            this.deviceWidth = deviceWidth;
        }

        // Getting Device Specific Values
        public float getFactoredValue(int value) {

            float refRatio = refHeight / refWidth;
            float devRatio = deviceHeight / deviceWidth;

            float factoredValue = value * ( refRatio / devRatio );

            Debug.WriteLine( "RR:" + refRatio + "  DR: " + devRatio + " DIV:" + ( refRatio / devRatio ) );
            Debug.WriteLine( "Calculated Value for " + value + "  : " + factoredValue );

            return factoredValue;
        }

        // Deriving Proportinate Height
        public float getFactoredHeight(int value) {
            return ( float ) ( ( value / refHeight ) * deviceHeight );
        }

        // Deriving Proportinate Width
        public float getFactoredWidth(int value) {
            return ( float ) ( ( value / refWidth ) * deviceWidth );
        }

        // Deriving Sweep Angle
        public int getSweepAngle(int goal, int achieved) {
            int SweepAngle = 260;
            float factor = ( float ) achieved / goal;
            Debug.WriteLine( "SWEEP ANGLE : " + ( int ) ( SweepAngle * factor ) );

            return ( int ) ( SweepAngle * factor );

        }

    }

    public class RadialProgress {
        SKPaintSurfaceEventArgs args;
        ProgressUtils progressUtils = new ProgressUtils();
        int dailyWorkout = 20;
        int monthlyWorkout = 340;
        int goal = 900;

        private SKCanvasView canvas;
        private Slider sweepAngleSlider;
        RadialProgress(SKCanvasView canvas, Slider sweepAngleSlider) {
            this.canvas = canvas;
            this.sweepAngleSlider = sweepAngleSlider;
        }
        // Initializing the canvas & drawing over it
        async Task OnCanvasViewPaintSurfaceAsync(object sender, SKPaintSurfaceEventArgs args1) {
            args = args1;
            await drawGaugeAsync();

        }

        // Event Handler for Switch Toggle
        void switchToggledAsync(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            initiateProgressUpdate();
        }


        void sliderValueChanged(object sender, ValueChangedEventArgs args) {
            if ( canvas != null ) {
                // Invalidating surface due to data change
                canvas.InvalidateSurface();
            }
        }


        // Animating the Progress of Radial Gauge
        async void animateProgress(int progress) {
            //sw_listToggle.IsEnabled = false;
            sweepAngleSlider.Value = 1;

            // Looping at data interval of 5
            for ( int i = 0; i < progress; i = i + 5 ) {
                sweepAngleSlider.Value = i;
                await Task.Delay( 3 );
            }

            sweepAngleSlider.Value = progress;
            //sw_listToggle.IsEnabled = true;

        }

        void initiateProgressUpdate() {
            if ( true )
                animateProgress( progressUtils.getSweepAngle( goal, monthlyWorkout ) );
            else
                animateProgress( progressUtils.getSweepAngle( goal / 30, dailyWorkout ) );
        }

        public async Task drawGaugeAsync() {
            // Radial Gauge Constants
            int uPadding = 150;
            int side = 500;
            int radialGaugeWidth = 25;

            // Line TextSize inside Radial Gauge
            int lineSize1 = 220;
            int lineSize2 = 70;
            int lineSize3 = 80;

            // Line Y Coordinate inside Radial Gauge
            int lineHeight1 = 100;
            int lineHeight2 = 200;
            int lineHeight3 = 300;

            // Start & End Angle for Radial Gauge
            float startAngle = -220;
            float sweepAngle = 260;

            try {

                // Getting Canvas Info 
                SKImageInfo info = args.Info;
                SKSurface surface = args.Surface;
                SKCanvas canvas = surface.Canvas;
                progressUtils.setDevice( info.Height, info.Width );
                canvas.Clear();

                // Getting Device Specific Screen Values
                // -------------------------------------------------

                // Top Padding for Radial Gauge
                float upperPading = progressUtils.getFactoredHeight( uPadding );

                /* Coordinate Plotting for Radial Gauge
                *
                *    (X1,Y1) ------------
                *           |   (XC,YC)  |
                *           |      .     |
                *         Y |            |
                *           |            |
                *            ------------ (X2,Y2))
                *                  X
                *   
                *To fit a perfect Circle inside --> X==Y
                *       i.e It should be a Square
                */

                // Xc & Yc are center of the Circle
                int Xc = info.Width / 2;
                float Yc = progressUtils.getFactoredHeight( side );

                // X1 Y1 are lefttop cordiates of rectange
                int X1 = ( int ) ( Xc - Yc );
                int Y1 = ( int ) ( Yc - Yc + upperPading );

                // X2 Y2 are rightbottom cordiates of rectange
                int X2 = ( int ) ( Xc + Yc );
                int Y2 = ( int ) ( Yc + Yc + upperPading );

                //Loggig Screen Specific Calculated Values
                Debug.WriteLine( "INFO " + info.Width + " - " + info.Height );
                Debug.WriteLine( " C : " + upperPading + "  " + info.Height );
                Debug.WriteLine( " C : " + Xc + "  " + Yc );
                Debug.WriteLine( "XY : " + X1 + "  " + Y1 );
                Debug.WriteLine( "XY : " + X2 + "  " + Y2 );

                //  Empty Gauge Styling
                SKPaint paint1 = new SKPaint {
                    Style = SKPaintStyle.Stroke,
                    Color = Color.FromHex( "#e0dfdf" ).ToSKColor(),                   // Colour of Radial Gauge
                    StrokeWidth = progressUtils.getFactoredWidth( radialGaugeWidth ), // Width of Radial Gauge
                    StrokeCap = SKStrokeCap.Round                                   // Round Corners for Radial Gauge
                };

                // Filled Gauge Styling
                SKPaint paint2 = new SKPaint {
                    Style = SKPaintStyle.Stroke,
                    Color = Color.FromHex( "#05c782" ).ToSKColor(),                   // Overlay Colour of Radial Gauge
                    StrokeWidth = progressUtils.getFactoredWidth( radialGaugeWidth ), // Overlay Width of Radial Gauge
                    StrokeCap = SKStrokeCap.Round                                   // Round Corners for Radial Gauge
                };

                // Defining boundaries for Gauge
                SKRect rect = new SKRect( X1, Y1, X2, Y2 );


                //canvas.DrawRect(rect, paint1);
                //canvas.DrawOval(rect, paint1);

                // Rendering Empty Gauge
                SKPath path1 = new SKPath();
                path1.AddArc( rect, startAngle, sweepAngle );
                canvas.DrawPath( path1, paint1 );

                // Rendering Filled Gauge
                SKPath path2 = new SKPath();
                path2.AddArc( rect, startAngle, ( float ) sweepAngleSlider.Value );
                canvas.DrawPath( path2, paint2 );

                //---------------- Drawing Text Over Gauge ---------------------------

                // Achieved Minutes
                using ( SKPaint skPaint = new SKPaint() ) {
                    skPaint.Style = SKPaintStyle.Fill;
                    skPaint.IsAntialias = true;
                    skPaint.Color = SKColor.Parse( "#676a69" );
                    skPaint.TextAlign = SKTextAlign.Center;
                    skPaint.TextSize = progressUtils.getFactoredHeight( lineSize1 );
                    skPaint.Typeface = SKTypeface.FromFamilyName(
                                        "Arial",
                                        SKFontStyleWeight.Bold,
                                        SKFontStyleWidth.Normal,
                                        SKFontStyleSlant.Upright );

                    // Drawing Achieved Minutes Over Radial Gauge
                    if ( true )
                        canvas.DrawText( monthlyWorkout + "", Xc, Yc + progressUtils.getFactoredHeight( lineHeight1 ), skPaint );
                    else
                        canvas.DrawText( dailyWorkout + "", Xc, Yc + progressUtils.getFactoredHeight( lineHeight1 ), skPaint );
                }

                // Achieved Minutes Text Styling
                using ( SKPaint skPaint = new SKPaint() ) {
                    skPaint.Style = SKPaintStyle.Fill;
                    skPaint.IsAntialias = true;
                    skPaint.Color = SKColor.Parse( "#676a69" );
                    skPaint.TextAlign = SKTextAlign.Center;
                    skPaint.TextSize = progressUtils.getFactoredHeight( lineSize2 );
                    canvas.DrawText( "Minutes", Xc, Yc + progressUtils.getFactoredHeight( lineHeight2 ), skPaint );
                }

                // Goal Minutes Text Styling
                using ( SKPaint skPaint = new SKPaint() ) {
                    skPaint.Style = SKPaintStyle.Fill;
                    skPaint.IsAntialias = true;
                    skPaint.Color = SKColor.Parse( "#e2797a" );
                    skPaint.TextAlign = SKTextAlign.Center;
                    skPaint.TextSize = progressUtils.getFactoredHeight( lineSize3 );

                    // Drawing Text Over Radial Gauge
                    if ( true )
                        canvas.DrawText( "Goal " + goal + " Min", Xc, Yc + progressUtils.getFactoredHeight( lineHeight3 ), skPaint );
                    else {
                        canvas.DrawText( "Goal " + goal / 30 + " Min", Xc, Yc + progressUtils.getFactoredHeight( lineHeight3 ), skPaint );
                    }
                }

            } catch ( Exception e ) {
                Debug.WriteLine( e.StackTrace );
            }
        }
    }
}
