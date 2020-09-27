using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Transforms
{
    // MASHUP OF OBLIQUE TEXT AND SKEW SHADOW
    class MashupTransform : ContentPage
    {
        public MashupTransform()
        {
            Title = "Skia Rocks";

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            //oblique
            using (SKPaint textPaint = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Maroon,
                TextAlign = SKTextAlign.Center,
                TextSize = info.Width / 14
            })
            {
                string text = "Skia Rocks";
                float xText = info.Width/2;
                float yText = info.Height / 2;

                // Shadow
                textPaint.Color = SKColors.LightGray;
                canvas.Save();
                canvas.Translate(xText, yText);
                canvas.Skew((float)Math.Tan(-Math.PI / 4), 0);
                canvas.Scale(1, 3);
                canvas.Translate(-xText, -yText);
                canvas.DrawText(text, xText, yText, textPaint);
                canvas.Restore();

                textPaint.Color = SKColors.CornflowerBlue;
                canvas.Translate(info.Width / 2, info.Height / 2);
                SkewDegrees(canvas, -20, 0);
                canvas.DrawText(Title, 0, 0, textPaint);
            }            

            void SkewDegrees(SKCanvas shadowCanvas, double xDegrees, double yDegrees)
            {
                shadowCanvas.Skew((float)Math.Tan(Math.PI * xDegrees / 180),
                            (float)Math.Tan(Math.PI * yDegrees / 180));
            }
        }
    }
}
